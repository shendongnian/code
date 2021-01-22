	public static bool TypeIs(this Type x, Type d) {
		if(null==d) {
			return false;
		}
		for(var c = x; null!=c; c=c.BaseType) {
			var a = c.GetInterfaces();
			for(var i = a.Length; i-->=0;) {
				var t = i<0 ? c : a[i];
				if(t==d||t.IsGenericType&&t.GetGenericTypeDefinition()==d) {
					return true;
				}
			}
		}
		return false;
	}
