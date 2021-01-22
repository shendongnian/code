    public static bool IsDescendantOf<T>(this object o)
    {
    	if(o == null) throw new ArgumentNullException();
    	return typeof(T).IsSubclassOf(o.GetType());
    }
