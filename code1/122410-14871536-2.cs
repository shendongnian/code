	class A
	{
		public int a { get;set; }
		public int b { get;set; }
		public int c { get;set; }
		public int d { get;set; }
		public string s { get;set; }
		
		public A(int _a, int _b, int _c, int _d, string _s)
		{
			a = _a;
			b = _b;
			c = _c;
			d = _d;
			s = _s;		
		}
	}
	void Main()
	{
		A[] ls = {
			new A(0,2,1,10,"one"),
			new A(0,1,1,11,"two"),
			new A(0,0,2,12,"three"),
			new A(0,2,2,13,"four"),
			new A(0,0,3,14,"five"),
			new A(1,0,3,15,"six"),
			new A(1,1,4,16,"se7en"),
			new A(1,0,4,17,"eight"),
			new A(1,1,5,18,"nine"),
			new A(1,2,5,19,"dunno")
		};
		
		var tree = ls.ToTree(x => x.a, x => x.b, x => x.c, x => x.d);
		
	}
