	class Base
	{
		private readonly string _s;
	
		public Base(string s)
		{
			_s = s.ToLower();
		}
	}
	class Derived
	{
		private readonly object _o;
		private readonly Base _b;
	
		public Derived(string path)
		{
			_o = new object();// initialize from path
			_b = new Base(_o.ToString());
		}		
	}
