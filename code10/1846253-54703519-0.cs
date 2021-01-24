	public abstract class A
	{
		public virtual void MethodX()
		  => Console.WriteLine("A - X");
		public virtual void MethodY()
		  => Console.WriteLine("A - Y");
	}
	public class B : A
	{
		public override void MethodY()
		  => Console.WriteLine("B - X");
		public override void MethodX()
		{
			Console.WriteLine("B - Y");
			MethodY();
		}
	}
	public class C : B
	{
		public override void MethodY()
		  => Console.WriteLine("C - Y");
		public override void MethodX()
		{
			Console.WriteLine("C - X");
			base.MethodX();
		}
	}
	public static void Main()
	{
		var c = new C();
		c.MethodX();
	}
