    public static void GetInfo<T>(string objectname, List<T> list, Func<T, string> getProperty)
	{
		T foundobject = list.Find(x => getProperty(x) == objectname);
        // ...
	}
