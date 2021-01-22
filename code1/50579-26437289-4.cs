        public Bar(Foo foo)
		{
			this.foo = foo;
			foo.SomeEvent += Handler;
		}
		public void Handler()
		{
			if (disposed)
				Console.WriteLine("Handler is called after object was disposed!");
		}
		public void Dispose()
		{
			foo.SomeEvent -= Handler;
			disposed = true;
		}
