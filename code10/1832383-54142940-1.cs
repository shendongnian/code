	public class Foo1
	{
		public string Bar1 { get; set; }
		public string Bar2 { get; set; }
		public string Bar3 { get; set; }
	}
	public class Foo2
	{
		public string Bar1 { get; set; }
		public string Bar2 { get; set; }
	}
	public class FooNumber
	{
		public Foo1 Foo1 { get; set; }
		public Foo2 Foo2 { get; set; }
	}
	public class Result
	{
		public FooNumber FooNumber { get; set; }
	}
	public class ObjetWSResult
	{
		public Result result { get; set; }
		public string mssg { get; set; }
	}
	public class RootObject
	{
		public bool success { get; set; }
		public ObjetWSResult objetWSResult { get; set; }
	}
