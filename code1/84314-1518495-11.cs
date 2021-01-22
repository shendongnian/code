    /// <summary>
    /// My benchmarking showed that for RNGCryptoServiceProvider:
    /// 1. There is negligable benefit of sharing RNGCryptoServiceProvider object reference 
    /// 2. Initial GetBytes takes 2ms, and an initial read of 1MB takes 3ms (starting to rise, but still negligable)
    /// 2. Cached is ~1000x faster for single byte at a time - taking 9ms over 1MB vs 989ms for uncached
    /// </summary>
    class SecureFastRandom
    {
    	static byte[] byteCache = new byte[1000000]; //My benchmark showed that an initial read takes 2ms, and an initial read of this size takes 3ms (starting to raise)
    	static int lastPosition = 0;
    	static int remaining = 0;
    
    	/// <summary>
    	/// Static direct uncached access to the RNGCryptoServiceProvider GetBytes function
    	/// </summary>
    	/// <param name="buffer"></param>
    	public static void DirectGetBytes(byte[] buffer)
    	{
    		using (var r = new RNGCryptoServiceProvider())
    		{
    			r.GetBytes(buffer);
    		}
    	}
    
    	/// <summary>
    	/// Main expected method to be called by user. Underlying random data is cached from RNGCryptoServiceProvider for best performance
    	/// </summary>
    	/// <param name="buffer"></param>
    	public static void GetBytes(byte[] buffer)
    	{
    		if (buffer.Length > byteCache.Length)
    		{
    			DirectGetBytes(buffer);
    			return;
    		}
    
    		lock (byteCache)
    		{
    			if (buffer.Length > remaining)
    			{
    				DirectGetBytes(byteCache);
    				lastPosition = 0;
    				remaining = byteCache.Length;
    			}
    
    			Buffer.BlockCopy(byteCache, lastPosition, buffer, 0, buffer.Length);
    			lastPosition += buffer.Length;
    			remaining -= buffer.Length;
    		}
    	}
    
    	/// <summary>
    	/// Return a single byte from the cache of random data.
    	/// </summary>
    	/// <returns></returns>
    	public static byte GetByte()
    	{
    		lock (byteCache)
    		{
    			return UnsafeGetByte();
    		}
    	}
    
    	/// <summary>
    	/// Shared with public GetByte and GetBytesWithMax, and not locked to reduce lock/unlocking in loops. Must be called within lock of byteCache.
    	/// </summary>
    	/// <returns></returns>
    	static byte UnsafeGetByte()
    	{
    		if (1 > remaining)
    		{
    			DirectGetBytes(byteCache);
    			lastPosition = 0;
    			remaining = byteCache.Length;
    		}
    
    		lastPosition++;
    		remaining--;
    		return byteCache[lastPosition - 1];
    	}
    
    	/// <summary>
    	/// Rejects bytes which are equal to or greater than max. This is useful for ensuring there is no bias when you are modulating with a non power of 2 number.
    	/// </summary>
    	/// <param name="buffer"></param>
    	/// <param name="max"></param>
    	public static void GetBytesWithMax(byte[] buffer, byte max)
    	{
    		if (buffer.Length > byteCache.Length / 2) //No point caching for larger sizes
    		{
    			DirectGetBytes(buffer);
    
    			lock (byteCache)
    			{
    				UnsafeCheckBytesMax(buffer, max);
    			}
    		}
    		else
    		{
    			lock (byteCache)
    			{
    				if (buffer.Length > remaining) //Recache if not enough remaining, discarding remaining - too much work to join two blocks
    					DirectGetBytes(byteCache);
    
    				Buffer.BlockCopy(byteCache, lastPosition, buffer, 0, buffer.Length);
    				lastPosition += buffer.Length;
    				remaining -= buffer.Length;
    
    				UnsafeCheckBytesMax(buffer, max);
    			}
    		}
    	}
    
    	/// <summary>
    	/// Checks buffer for bytes equal and above max. Must be called within lock of byteCache.
    	/// </summary>
    	/// <param name="buffer"></param>
    	/// <param name="max"></param>
    	static void UnsafeCheckBytesMax(byte[] buffer, byte max)
    	{
    		for (int i = 0; i < buffer.Length; i++)
    		{
    			while (buffer[i] >= max)
    				buffer[i] = UnsafeGetByte(); //Replace all bytes which are equal or above max
    		}
    	}
    }
