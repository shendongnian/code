	public static class Program {
		[STAThread()]
		public static void Main(params String[] args) {
			Int32 x = 2;
			unsafe {
				Int32* ptr = &x;
				Console.WriteLine("pointer: {0}", *ptr);
				*ptr = 400;
				Console.WriteLine("pointer (new value): {0}", *ptr);
			}
			Console.WriteLine("non-pointer: " + x);
			Console.ReadKey(true);
		}
	}
