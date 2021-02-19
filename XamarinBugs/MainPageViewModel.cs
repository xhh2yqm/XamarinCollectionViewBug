using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBugs
{
    public class MainPageViewModel: INotifyPropertyChanged, IDisposable
    {

        private bool _isRefreshing;
        private bool headerVisible;
        private bool headerFilterVisible;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshAsync());
        public ICommand btn1command => new Command(async () => await btn1commandasync());
        public ICommand btn2command => new Command(async () => await btn2commandasync());
        public ICommand filtercommand => new Command(async () => await filtercommandasync());

        private async Task btn2commandasync()
        {

            HeaderVisible = true;
            await Task.Delay(500); 
        }
        private async Task filtercommandasync()
        {

            HeaderFilterVisible = !headerFilterVisible;
            await Task.Delay(500);
        }
        private async Task btn1commandasync()
        {
            HeaderVisible = false;
            await Task.Delay(500);

        }

        private async Task RefreshAsync()
        {
            Console.WriteLine("Started REFRESHING");
            await Task.Delay(10000);
            Console.WriteLine("Finished REFRESHING"); 
            IsRefreshing = false; 

        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public bool HeaderFilterVisible
        {
            get
            {
                return headerFilterVisible;
            }
            set
            {
                headerFilterVisible = value;
                OnPropertyChanged();
            }
        }
        public bool HeaderVisible
        {
            get
            {
                return headerVisible;
            }
            set
            {
                headerVisible = value;
                OnPropertyChanged();
            }
        }
        string headerLabel; 
        public string HeaderLabel
        {
            get
            {
                return headerLabel;
            }
            set
            {
                headerLabel = value;
                OnPropertyChanged();
            }
        }
        public MainPageViewModel()
        {
            HeaderLabel = "COLLECTION VIEW HEADER SECTION"; 
        }
    }
}
