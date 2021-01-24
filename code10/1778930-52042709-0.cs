	public class Test
	{
		public int P { get; set; }
		public Action<Test> A;
		public void Run()
		{
			this.A(this);
		}
	}
