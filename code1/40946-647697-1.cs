    public static bool IsNull(this object o)
    {
		return string.IsNullOrEmpty(o.ToStr());
    }
	public static bool IsNotNull(this object o)
	{
		return !string.IsNullOrEmpty(o.ToStr());
	}
	public static string ToStr(this object o)
	{
		return o + "";
	}
