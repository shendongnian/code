	interface I
	{
		void F();
		void G();
	}
	class DefaultI : I
	{
		void F() { ... }
		void G() { ... }
	}
	class C : I = DefaultI
	{
		public void F() { ... } // implements I.F
	}
