	public class Foo
	{
		internal Foo() { }
		protected virtual string Thing() { return "foo"; }
	}
	public class Bar : Foo
	{
	 internal new string Thing() { return "bar"; }
	}
