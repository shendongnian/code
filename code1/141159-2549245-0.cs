	public interface ISomeService
	{
		string Method1();
		string Method2();
	}
	public class ReLoginWebService : ISomeService
	{
		readonly WebServiceProxy _proxy;
		string _username;
		string _password;
		public ReLoginWebService(string username, string password)
		{
			_username = username;
			_password = password;
			_proxy = new WebServiceProxy();
			Login();
		}
		public string Method1()
		{
			try
			{
				_proxy.Method1();
			}
			catch (Exception exp) // filter appropriatly...
			{
				// if its a login error...
				if (Login())
					_proxy.Method1();
				else
					throw;
			}
			return "";
		}
		public string Method2()
		{
			try
			{
				_proxy.Method2();
			}
			catch (Exception exp) // filter appropriatly...
			{
				// if its a login error...
				if (Login())
					_proxy.Method2();
				else
					throw;
			}
			return "";
		}
		protected bool Login()
		{
			return true; // i.e. success
		}
	}
