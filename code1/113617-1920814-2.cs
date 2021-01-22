	class BaseClass
	{
		private readonly object objectA = new object(); // Second
		private readonly object objectB;
		public BaseClass()
		{
			this.objectB = new object(); // Third
		}
	}
	class DerivedClass : BaseClass
	{
		private object objectC = new object(); // First
		private object objectD;
		public DerivedClass()
		{
			this.objectD = new object(); // Forth
		}
	}
