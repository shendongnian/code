	public class A : A<C>
	{
	}
	
	public class B : A<D>
	{
		public void DoMoreStuff()
		{
			this.DoStuff();
			Console.WriteLine(this.Obj.GetType().FullName);
		}
	}
