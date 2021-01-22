	class C1 : IDisposable
	{
		public C1()
		{
		}
		public void Dispose()
		{
			Console.WriteLine( "Destroyed C1" );
		}
	}
	class C2 : IDisposable
	{
		public C2()
		{
			throw new Exception();
		}
		public void Dispose()
		{
			Console.WriteLine( "Destroyed C2" );
		}
	}
	class C3 : IDisposable
	{
		C1 c1;
		C2 c2;
		public C3()
		{
			try {
				c1 = new C1();
				c2 = new C2();
			} catch (Exception e) {
				throw new Exception();
			}
		}
		~C3()
		{
			this.Dispose();
		}
		public void Dispose()
		{
			if ( c1 != null )
				c1.Dispose();
			if ( c2 != null )
				c2.Dispose();
		}
	}
