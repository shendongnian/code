cs
    class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine((new B()).theValue);
			Console.WriteLine((new C()).theValue);
			Console.ReadKey();
		}
	}
	public abstract class A
	{
		public readonly string theValue;
		protected A(string s)
		{
			theValue = s;
		}
	}
	public class B : A
	{
		public B(): base("Banana")
		{
		}
	}
	public class C : A
	{
		public C(): base("Coconut")
		{
		}
	}
