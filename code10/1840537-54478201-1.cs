	public class ParentViewModel
	{
		private ClassA ClassA = new ClassA();
		private ClassB ClassB = new ClassB();
		public int MyValue ... // <- implements INPC
		public ParentViewModel()
		{
			this.ClassA.OnChanged += (s, e) => this.MyValue = e;
			this.ClassB.OnChanged += (s, e) => this.MyValue = e;
		}
	}
