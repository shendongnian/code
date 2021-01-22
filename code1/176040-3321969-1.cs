    public class MainPage_ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<object> MyCollection
        {
            get { return myCollection; }
            set 
            {
                if (myCollection != value)
                {
                    myCollection = value;
                    OnPropertyChanged("MyCollection");
                }
            }
        }
        private ObservableCollection<object> myCollection = new ObservableCollection<object>();
        public void LoadData()
        {
            //execute load method, the assign result to MyCollection
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
