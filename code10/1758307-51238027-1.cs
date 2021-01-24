	public interface IDoLogin
	{
	    void DoLogin(AccountModel account);
	}
	
	public class Desktop : IDoLogin
	{
		private ChromeDriver _webDriver;
		
		public Desktop(ChromeDriver webDriver)
		{
			_webDriver = webDriver;
		}
		
	    public void DoLogin(AccountModel account) { }
	}
	
	public class Mobile : IDoLogin
	{
		private ChromeDriver _webDriver;
		
		public Mobile(ChromeDriver webDriver)
		{
			_webDriver = webDriver;
		}
		
	    public void DoLogin(AccountModel account) { }
	}
	
	public class ChromeDriver
	{
		public Desktop Desktop;
		public Mobile Mobile;
		
		public ChromeDriver()
		{
			this.Desktop = new Desktop(this);
			this.Mobile = new Mobile(this);
		}
	}
