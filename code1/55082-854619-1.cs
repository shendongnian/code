	public static class Get<T> {
		public static T If<U>(U item, Func<U, T> lambda) where U: class {
			if (item == null) {
				return default(T);
			}
			return lambda(item);
		}
	}
	var x = new One();
	string fooIfNotNull = Get<string>.If(
	                      Get<Four>.If(
	                      Get<Three>.If(
	                      Get<Two>.If(x, one => one.Two),
	                                     two => two.Three),
	                                     three => three.Four),
	                                     four => four.Foo);
