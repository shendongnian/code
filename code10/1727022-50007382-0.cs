    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool displayProgress;
        public bool DisplayProgress
        {
            get { return displayProgress; }
            set
            {
                displayProgress = value;
                NotifyPropertyChanged();
            }
        }
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task<List<string>> LoadData()
        {
            DisplayProgress = true;
            //Here connect to the database and graph your data
            await Task.Run(() =>
            {
                Thread.Sleep(5000);//to demonstrate the delay
            });
            DisplayProgress = false;
            return new List<string>() { "A", "B", "C" };
        }
    }
