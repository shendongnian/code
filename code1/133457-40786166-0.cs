    public class User
	{
		public string Login { get; set; }
	}
    public class UserDetail : User
	{
		[Display(Name = "Login:")]
		public new string Login => base.Login;
	}
