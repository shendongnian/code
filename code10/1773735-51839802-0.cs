	public abstract class A<T> where T : C
	{
		public T Obj { get; set; }
	
		public void DoStuff()
		{
			Console.WriteLine(typeof(T).FullName);
			Console.WriteLine(this.Obj.GetType().FullName);
		}
	}
