	class Test
	{
		public class Foo
		{
			Dictionary<string, int> data =new Dictionary<string,int>();
			public int this[string index]
			{
				get { return data[index]; }
				set { data[index] = value; }
			}
			public Foo()
			{
				data["a"] = 1;
				data["b"] = 2;
			}
		}
		public Test()
		{
			var foo = new Foo();
			var property = foo.GetType().GetProperty("Item");
			var value = (int)property.GetValue(foo, new object[] { "a" });
			int i = 0;
		}
	}
