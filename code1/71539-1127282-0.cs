	interface ISomething
	{
		void DoSomething();
	}
	class NormalType : ISomething
	{
		// ...
		public void DoSomething() { /* nothing to do */ }
	}
	class SpecialType : ISomething
	{
		// ...
		public void DoSomething() { this.SpecialString = "foo" }
	}
	class MyGenericClass : ICloneable
	{
		private ISomething m_storedClass;
		private DoStuff()
		{
			// ...
			m_storedClass.DoSomething();
		}
	}
