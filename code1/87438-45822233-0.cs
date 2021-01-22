    class Program
	{
		static void Main(string[] args)
		{
			var test = new DerivedClass();
			var result = test.DoSomething();
		}
	}
	class BaseClass
	{
		public virtual string DoSomething()
		{
			return "Base result";
		}
	}
	class DerivedClass : BaseClass
	{
		public new string DoSomething()
		{
			return "Derived result";
		}
	}
