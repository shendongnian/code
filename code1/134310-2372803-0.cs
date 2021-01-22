    public static int[] ToIntArray(this string value)
    {
    	return value.Split(',')
    		.Select<string, int>(s => int.Parse(s))
    		.ToArray<int>();
    }
