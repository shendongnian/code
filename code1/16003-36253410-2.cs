	public abstract class Mixin1 : Mixin {}
	public abstract class Mixin2 : Mixin {}
	public abstract class Mixin3 : Mixin {}
	public class Test : Has<Mixin1>, Has<Mixin2> {
		private class Mixin1Impl : Mixin1 {
			public static readonly Mixin1Impl Instance = new Mixin1Impl();
		}
		private class Mixin2Impl : Mixin2 {
			public static readonly Mixin2Impl Instance = new Mixin2Impl();
		}
		Mixin1 Has<Mixin1>.Mixin => Mixin1Impl.Instance;
		Mixin2 Has<Mixin2>.Mixin => Mixin2Impl.Instance;
	}
	static class TestThis {
		public static void run() {
			var t = new Test();
			var a = t.Mixout<Mixin1>();
			var b = t.Mixout<Mixin2>();
		}
	}
