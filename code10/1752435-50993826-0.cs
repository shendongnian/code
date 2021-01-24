	using System;
						
	public class Program
	{
		public static void Main()
		{		
			var p = new Program();
			
			object s = "Hi";
			object i = 42;
			object f = 3.14;
			
			p.Test(s);
			p.Test(i);
			p.Test(f);
			
			p.SetTestType(GetConfigType());
			
			p.ConfiguredTest("Hello");
			p.ConfiguredTest(s);
		}
		
		public static Type GetConfigType() { return typeof(string); }
	
		
		
		Action<object> ConfiguredTest;
	
		void SetTestType(Type type)
		{
			if (type == typeof(string))
				ConfiguredTest = o => Test((string)o);
			
			else if (type == typeof(int))
				ConfiguredTest = o => Test((int)o);
			
			else
				ConfiguredTest = null;
		}
		
		void Test(object o) // catch-all when type is not known until runtime
		{
			if (ConfiguredTest != null)
			{
				ConfiguredTest(o); // if type is configured, we can skip type checking
			}
			else // if type is not configured, check for supported types
			{
				if (o is string)
					Test((string)o);
				
				else if (o is int)
					Test((int)o);
					
				else
					Console.WriteLine("Unsupported type: " + o.GetType());
			}
		}
		
		void Test(int i) { Console.WriteLine("Int = " + i); }
		
		void Test(String s) { Console.WriteLine("String = " + s); }
	
	}
