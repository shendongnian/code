    class Program
    	{
    		static void Main(string[] args)
    		{
    			Managed m = new Managed();
    			Console.WriteLine(m.PrivateSetter);
    			m.Mgr.SetProperty("lol");
    			Console.WriteLine(m.PrivateSetter);
    			Console.Read();
    		}
    	}
    
    	public class Managed
    	{
    		private Manager _mgr;
    		public Manager Mgr
    		{
    			get { return _mgr ?? (_mgr = new Manager(s => PrivateSetter = s)); }
    		}
    		public string PrivateSetter { get; private set; }
    		public Managed()
    		{
    			PrivateSetter = "Unset";
    		}
    	}
    
    	public class Manager
    	{
    		private Action<string> _setPrivateProperty;
    		public Manager(Action<string> setter)
    		{
    			_setPrivateProperty = setter;
    		}
    		public void SetProperty(string value)
    		{
    			_setPrivateProperty(value);
    		}
    	}
