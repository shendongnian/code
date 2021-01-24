    public class StatusInfo : INotifyPropertyChanged
    {
        private string screenStatusBarText = "Initialized";
        public string ScreenStatusBarText
        {
            get { return screenStatusBarText; }
            set
            {
                screenStatusBarText = value;
                OnPropertyChanged(nameof(ScreenStatusBarText));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
