    public class MyViewModel
    {
        private User _selectedUser;
        public MyViewModel()
        {
            Users = new ObservableCollection<User>
            {
                new User{FirstName = "User A FirstName", LastName = "User A LastName"},
                new User{FirstName = "User B FirstName", LastName = "User B LastName"},
                new User{FirstName = "User C FirstName", LastName = "User C LastName"}
            };
        }
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                Debug.WriteLine(_selectedUser.LastName);
            }
        }
    }
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
