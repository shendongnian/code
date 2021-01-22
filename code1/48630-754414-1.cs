		class A { }
		struct B { }
		static void foo(A a) { }
		static void bar(B b) { }
		static void Main(string[] args)
		{
			foo(null);
			bar(null);
		}
