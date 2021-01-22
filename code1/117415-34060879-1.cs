    	Locker lo = Locker.Create();
		private void Foo()
		{
			if (lo.IsActive) return;
			using(lo.Activate())
			{
				Console.WriteLine("Foo");
				Bar();
			}
		}
		private void Bar()
		{
			Console.WriteLine("Bar");
			Foo();
		}
