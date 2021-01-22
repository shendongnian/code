    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _listOfUsers;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<User> ListOfUsers
        {
            get { return _listOfUsers; }
            set
            {
                if (_listOfUsers == value) return;
                _listOfUsers = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ListOfUsers"));
            }
        }
    }
