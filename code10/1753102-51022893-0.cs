    public static class TypeHasher
    {
    	private static ConcurrentDictionary<Type, byte[]> cache = new ConcurrentDictionary<Type, byte[]>();
    	public static byte[] GetHash(Type type)
    	{
    		byte[] result;
    		if (!cache.TryGetValue(type, out result))
    		{
    			Console.WriteLine("Computing Hash for {0}", type.FullName);
    			SHA256Managed sha = new SHA256Managed();
    			result = sha.ComputeHash(Encoding.UTF8.GetBytes(type.FullName));
    			cache.TryAdd(type, result);
    		}
    		else
    		{
    			// Not actually required, but shows that hashing only done once per type
    			Console.WriteLine("Using cached Hash for {0}", type.FullName);
    		}
    
    		return result;
    	}
    }
