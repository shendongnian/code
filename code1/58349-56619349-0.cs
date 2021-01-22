	public static Type GetEnumerableType(this Type t) {
		return !typeof(IEnumerable).IsAssignableFrom(t) ? null : (
		from it in (new[] { t }).Concat(t.GetInterfaces())
		where it.IsGenericType
		where typeof(IEnumerable<>)==it.GetGenericTypeDefinition()
		from x in it.GetGenericArguments() // x represents the unknown
		let b = it.IsConstructedGenericType // b stand for boolean
		select b ? x : x.BaseType).FirstOrDefault()??typeof(object);
	}
