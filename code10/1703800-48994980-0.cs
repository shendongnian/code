	using System;
						
	public class Program
	{
		public static void Main()
		{
			var foo1 = new Foo(){Name = "Test"};
			var foo2 = foo1;
			// at this point both foo1 and foo2 are pointers to the same location in memory 
			// test
			Console.WriteLine("foo1.Name = " + foo1.Name);
			Console.WriteLine("foo2.Name = " + foo2.Name);
			
			// reassign the pointer for foo1
			Reassign(ref foo1);
			// at this point foo1 has been reassigned to a new location in memory, foo2 remains unchanged and still points to the original object in memory created earlier
			Console.WriteLine("foo1.Name = " + foo1.Name);
			Console.WriteLine("foo2.Name = " + foo2.Name);
		}
		
		
		public static void Reassign(ref Foo f)
		{
			// at this point you are reassigning exactly 1 pointer
			f = new Foo()
			{
				Name = System.DateTime.Now.ToString()
			};
		}
	}
	public class Foo
	{
		public string Name {get;set;}
	}
