	public class Base
	{
		public virtual void Method(int input)
		{
		}
	}
	public class Super : Base
	{
		public override void Method(int input)
		{
			dynamic x = input;
			base.Method(x); // invalid
		}
	}
