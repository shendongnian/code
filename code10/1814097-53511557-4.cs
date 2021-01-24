    public class FolderInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
        private string _FolderName;
        public string FolderName
        {
            get { return _FolderName; }
            set
            {
                if (_FolderName != value)
                {
                    _FolderName = value;
                    RaisePropertyChanged("FolderName");
                }
            }
        }
        public ObservableCollection<FolderInfo> subFolders { get; set; } = new ObservableCollection<FolderInfo>();
        public override string ToString()
        {
            return FolderName;
        }
    }
