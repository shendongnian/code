	public class LogonViewModel : ViewModel
	{
		private readonly ICollection<User> _users;
		private User _selectedUser;
		private string _userEntry;
		public LogonViewModel()
		{
			_users = new List<User>();
			//fake data
			_users.Add(new User("Kent"));
			_users.Add(new User("Tempany"));
		}
		public ICollection<User> Users
		{
			get { return _users; }
		}
		public User SelectedUser
		{
			get { return _selectedUser; }
			set
			{
				if (_selectedUser != value)
				{
					_selectedUser = value;
					OnPropertyChanged("SelectedUser");
					UserEntry = value == null ? null : value.Name;
				}
			}
		}
		public string UserEntry
		{
			get { return _userEntry; }
			set
			{
				if (_userEntry != value)
				{
					_userEntry = value;
					OnPropertyChanged("UserEntry");
					DoSearch();
				}
			}
		}
		private void DoSearch()
		{
			//do whatever fuzzy logic you want here - I'm just doing a simple match
			SelectedUser = Users.FirstOrDefault(user => user.Name.StartsWith(UserEntry, StringComparison.OrdinalIgnoreCase));
		}
	}
