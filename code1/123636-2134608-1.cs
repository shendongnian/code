	public class Singleton
	{
		private Singleton() { }
		
		public static Singleton Instance 
		{	
			get
			{
				if (HttpContext.Current.Items["yourKey"] == null)
					HttpContext.Current.Items["yourKey"] = new Singleton();
				return (Singleton)HttpContext.Current.Items["yourKey"];
			}
		}
	}
