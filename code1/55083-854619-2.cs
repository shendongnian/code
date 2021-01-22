	public static class Get {
		public static T IfNotNull<T, U>(this U item, Func<U, T> lambda) where U: class {
			if (item == null) {
				return default(T);
			}
			return lambda(item);
		}
	}
	var one = new One();
	string fooIfNotNull = one.IfNotNull(x => x.Two).IfNotNull(x => x.Three).IfNotNull(x => x.Four).IfNotNull(x => x.Foo);
