	using System;
    using System.Diagnostics;
    
    class MyClass
	{
		public static Object _field = Program.init();
		public static void TouchMe() { }
	};
	class Program
	{
		static String methodcall, fieldinit;
		public static Object init() { return fieldinit = "fieldinit"; }
		static void Main(String[] args)
		{
			if (args.Length != 0)
			{
				methodcall = "TouchMe";
				MyClass.TouchMe();
			}
			Console.WriteLine("{0,18}  {1,7}  {2}", clrver(), methodcall, fieldinit);
		}
	};
