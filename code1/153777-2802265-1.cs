	public static bool IsList(object obj)
	{
		System.Collections.IList list = obj as System.Collections.IList;
		return list != null;
	}
	public static bool IsCollection(object obj)
	{
		System.Collections.ICollection coll = obj as System.Collections.ICollection;
		return coll != null;
	}
	public static bool IsDictionary(object obj)
	{
		System.Collections.IDictionary dictionary = obj as System.Collections.IDictionary;
		return dictionary != null;
	}
