	class Derived : Base
	{
		private readonly object _o;
	
		private Derived(object o, string s) : base(s)
		{
			_o = o;
		}
		
		public static Derived Create(string path)
		{
			var o = new object();// initialize from path
			var s = o.ToString(); // get s from o.
			return new Derived(o, s)
		}
	}
