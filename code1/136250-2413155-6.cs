	class StructBox
	{
		public static void Test()
		{
			using(MyStruct m = new MyStruct())
			{
				
			}
			MyStruct m2 = new MyStruct();
			DisposeSomething(m2);
		}
		public static void DisposeSomething(IDisposable disposable)
		{
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		private struct MyStruct : IDisposable
		{			
			public void Dispose()
			{
				// just kidding
			}
		}
	}
