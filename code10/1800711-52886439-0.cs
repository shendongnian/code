    static class Extensions
    {
	public static IEnumerable<Type> BaseTypes(this Type type)
	{
		Type t = type;
		while (true)
		{
			t = t.BaseType;
			if (t == null) break;
			yield return t;
		}
	}
    }
