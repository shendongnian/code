    internal static string GetKey<TEntity>(int id, params object[] args)
    {
        return string.Format("{0}#{1}[{2}]", typeof(TEntity).FullName, id, ArrayHash(args));
    }
    
    static string ArrayHash(params object[] values)
    {
    	return BitConverter.ToString(BitConverter.GetBytes(ArrayHashCode(values))).Replace("-", "").ToLowerInvariant();
    }
    
    static int ArrayHashCode(params object[] values)
    {
        if (values == null || values.Length == 0) return 0;
    	var value = values[0];
        int hashCode = value == null ? 0 : value.GetHashCode();
        for (int i = 1; i < values.Length; i++)
        {
    		value = values[i];
		    unchecked
		    {
        	    hashCode = (hashCode * 397) ^ (value == null ? 0 : value.GetHashCode());
		    }
        }
        return hashCode;
    }
