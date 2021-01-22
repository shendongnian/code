    	public class Person : PropertyNotifier, IPerson
	{
		private string _FirstName;
		private string _LastName;
		public String FirstName
		{
			get { return _FirstName; }
			set { SetProperty(ref _FirstName, value); }
		}
		public String LastName
		{
			get { return _LastName; }
			set { SetProperty(ref _LastName, value); }
		}
	}
