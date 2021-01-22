		interface IFoo
		{
			Type FooType { get; }
			string Name { get; set; }
		}
		class FooWithValue<T> : IFoo
		{
			public Type FooType { get { return typeof(T); }}
			public string Name { get; set; }
			public T Value { get; set; }
		}
