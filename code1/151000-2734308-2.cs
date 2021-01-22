	abstract class A
	{
		public virtual void SomeBehavior()
		{
			Console.WriteLine("default behavior");
		}
	}
	class B:A
	{
		public override void SomeBehavior()
		{
			 Console.WriteLine("type specific behavior");
		}
	}
	class C:A
	{
		public override void SomeBehavior()
		{
			 Console.WriteLine("different behavior");
		}
	}
	class D:A{}
	void Main()
	{
		IEnumerable<A> myCollection=new A[]{new B(),new C(),new D()};
		foreach(A item in myCollection)
		{
			item.SomeBehavior();
		}
	}
