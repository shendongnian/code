    public class MyWebApiClass : MyBaseClass<MyDependency>
	{
		public MyWebApiClass(MyDependency resolvedDependency) : base(resolvedDependency) { }
	}
	public class MyDependency
	{
		public string Foo { get; set; }
		public MyDependency()
		{
			Foo = "Bar";
		}
	}
