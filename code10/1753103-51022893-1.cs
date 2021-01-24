    public static class IdExtension
    {
    	public static byte[] GetId(this object obj)
    	{
    		return TypeHasher.GetHash(obj.GetType());
    	}
    }
