	public class MyClass
	{
		private static readonly int someStaticField;
		static MyClass() { someStaticField = 1; }
		// any no-op method call accepting your object will do fine
		public static void TouchMe() { GC.KeepAlive(someStaticField); }
	}
