    public static void GetInfo<T>(string objectname, List<T> list, Func<T, string> getProperty) 
        where T: IInformable
	{
		T foundobject = list.Find(x => getProperty(x) == objectname);
		foundobject.Info();
	}
