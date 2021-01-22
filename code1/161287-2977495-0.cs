    public class Singleton
	{
		private static Singleton instance = new Singleton();
		private Singleton() { }
		public static Singleton Instance { get { return instance; } }
		public void a(B b)
		{
			b.c();
		}
	}
	public class B
	{
		static void Main()
		{
			B b = new B();
			Singleton.Instance.a(b);
		}
		public void c()
		{
			// whatever you want it to do
		}
	}
