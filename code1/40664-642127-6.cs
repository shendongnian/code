	public class User : ViewModel
	{
		private readonly string _name;
		public User(string name)
		{
			_name = name;
		}
		public string Name
		{
			get { return _name; }
		}
	}
