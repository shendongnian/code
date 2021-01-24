    public class user
	{
		public string Name { get; set; }
		public DateTime PasswordLastSet { get; set; }
		
		public user()
		{
		    PasswordLastSet = DateTime.MinValue;
		}
	}
    
