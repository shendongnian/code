	public interface IFoo {
		void DoFoo();
	}
	public class Foo : IFoo {
		public void DoFoo() { Console.Write("Foo"); }
	}
	public class Bar {
		public void DoBar() { Console.Write("Bar"); }
	}
	public class FooBar : IFoo, Bar {
		private IFoo baseFoo = new Foo();
		public void DoFoo() { baseFoo.DoFoo(); }
	}
	//...
	FooBar fooBar = new FooBar();
	fooBar.DoFoo();
	fooBar.DoBar();
