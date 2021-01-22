    	class B
		{
			public void M(object o)
			{
				dynamic i = this;
				i.P = o;
			}
		}
		class D : B
		{
			public object P { get; set; }
		}
		class Program
		{
			static void Main()
			{
				var d = new D();
				d.M(1);
			}
		}
