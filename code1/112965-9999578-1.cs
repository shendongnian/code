	[TestFixture]
	public class Demo
	{
		public void print(int i)
		{
			Console.WriteLine("Int: "+i);
		}
		private delegate void mydelegate(int i);
		[StructLayout(LayoutKind.Explicit)]
		struct funky
		{
			[FieldOffset(0)]
			public mydelegate a;
			[FieldOffset(0)]
			public System.Action<int> b;
		}
		[Test]
		public void delegatetest()
		{
			System.Action<int> f = print;
			funky myfunky;
			myfunky.a = null;
			myfunky.b = f;
			mydelegate a = myfunky.a;
			a(5);
		}
    }
