	public class Base
	{
		public virtual void hello()
		{
		}
	}
	//
	public class Parent_1 : Base
	{
		public override void hello()
		{
			Console.WriteLine("Hi 1");
		}
	}
	public class Parent_2 : Parent_1
	{
		public override void hello()
		{
			base.hello();
			Console.WriteLine("Hi 2");
		}
	}
	public static void Main()
	{
		Parent_1 p = new Parent_2();
		p.hello();
	}
