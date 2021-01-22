    public static List<T> ToList<T>(DataTable dt)
        where T : IFoo, new()
    {
    	List<T> list = new List<T>();
    
    	foreach (DataRow dr in dt.Rows)
        {
            T t = new T();
            t.Initialize(dr);
            list.Add(t);
        }
    	return list;
    }
