      public partial class MainWindow : Window, INotifyPropertyChanged
      {
        private string outputFolderPath;
        public string OutputFolderPath
        {
            get { return outputFolderPath; }
            set
            {
                outputFolderPath = value;
                OnPropertyChanged("OutputFolderPath");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                        
        }
      }
