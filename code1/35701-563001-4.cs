        interface IFoo
		{
			string Name { get; set; }
		}
		class FooWithValue<T> : IFoo
		{
			public string Name { get; set; }
			public T Value { get; set; }
		}
