    public class UsersViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        private ICollectionView _usersView;
        public ObservableCollection<string> Filters { get; set; }
        public UsersViewModel()
        {
            _usersView = CollectionViewSource.GetDefaultView(Users);
            _usersView.Filter = delegate (object item)
            {
                User user = item as User;
                List<string> columns = new List<string>() { user.FirstName, user.LastName, user.Age };
                bool include = true;
                for (int i = 0; i < columns.Count; ++i)
                {
                    if (!string.IsNullOrEmpty(Filters[i]) && columns[i].IndexOf(Filters[i], StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        include = false;
                        break;
                    }
                }
                return include;
            };
            Filters.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => _usersView.Refresh();
        }
    }
