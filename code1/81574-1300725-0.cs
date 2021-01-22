    public T[] Concatenate<T>(T[] a, T[] b)
    {
    	if (a == null) throw new ArgumentNullException("a");
    	if (b == null) throw new ArgumentNullException("b");
    
    	T[] result = new T[a.Length + b.Length];
    	Array.Copy(a, result, a.Length);
    	Array.Copy(b, 0, result, a.Length, b.Length);
    	return result;
    }
