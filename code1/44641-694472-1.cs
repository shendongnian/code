	public class A {
		internal A() { }
		internal Initialize(int i) { Foo = i; }
		public int Foo { get; set; }
	}
	public class B : A { 
		internal B() { }
	}
	...
	public T Load<T>() where T : A, new() {
		var ret = new T();
		ret.Initialize(i);
		return ret;
	}
