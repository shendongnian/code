	class Test2 {
        delegate void Setter<T>(T value);
		public static void Test() {
			var someObject = new SomeObject();
			Setter<string> setter = (v) => { t.SomeProperty = v; };
			setter.DynamicInvoke(new object[]{propValue});
		}
	}
