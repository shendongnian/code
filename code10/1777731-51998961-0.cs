	public class ClassA
	{
		public string A { get; set; }
		public string B { get; set; }
		public string C { get; set; }
	}
	public class ClassB
	{
		public string E { get; set; }
		public string A { get; set; }
		public string G { get; set; }
	}
	public class ClassC
	{
		public string A { get; set; }
		public string B { get; set; }
	}
	public class ClassD
	{
		public string A { get; set; }
	}
	public class Wrapper
	{
		public ClassA classA { get; set; }
		public ClassB classB { get; set; }
		public ClassC classC { get; set; }
		public ClassD classD { get; set; }
	}
