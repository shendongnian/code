    public static TResult[] Concatenate<TResult, T1, T2>(T1[] a, T2[] b)
    	where T1 : TResult where T2 : TResult
    {
    	if (a == null) throw new ArgumentNullException("a");
    	if (b == null) throw new ArgumentNullException("b");
    
    	TResult[] result = new TResult[a.Length + b.Length];
    	Array.Copy(a, result, a.Length);
    	Array.Copy(b, 0, result, a.Length, b.Length);
    	return result;
    }
