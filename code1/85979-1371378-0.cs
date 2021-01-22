	namespace TypeInferenceDemo
	{
		class Program
		{
	
			static void Main(string[] args)
			{
				object str = "Hello World";
				object num = 5;
				object obj = new object();
	
				Console.WriteLine("var\tvalue\t\tFoo() Type\tCallFoo() Type");
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("{0}\t{1}\t{2}\t{3}", "str", str, MyClass.Foo(str), MyClass.CallFoo(str));
				Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", "num", num, MyClass.Foo(num), MyClass.CallFoo(num));
				Console.WriteLine("{0}\t{1}\t{2}\t{3}", "obj", obj, MyClass.Foo(obj), MyClass.CallFoo(obj));
			}
	
		}
	
		class MyClass
		{
			public static Type Foo<T>(T param)
			{
				return typeof(T);
			}
	
			public static Type CallFoo(object param)
			{
				return (Type)typeof(MyClass).GetMethod("Foo").MakeGenericMethod(new[] { param.GetType() }).Invoke(null, new[] { param });
			}
	
		}
	}
