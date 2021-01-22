    // Convert an object to a byte array
    public static byte[] ObjectToByteArray(Object obj)
    {
    	BinaryFormatter bf = new BinaryFormatter();
    	using (var ms = new MemoryStream())
    	{
    		bf.Serialize(ms, obj);
    		return ms.ToArray();
    	}
    }
