	using System;
	using System.Collections.Generic;
	
	public class AGenericClass<T> {
		public class NestedNonGenericClass {
			public void DoSomething() {
				Console.WriteLine("typeof(T) == " + typeof(T));
			}
		}
	}
	
	public class MyClass {
		public static void Main() 	{
			var c = new AGenericClass<int>.NestedNonGenericClass();
			var d = new AGenericClass<DateTime>.NestedNonGenericClass();
			c.DoSomething();
			d.DoSomething();
			Console.ReadKey(false);	
		}
		
	}
