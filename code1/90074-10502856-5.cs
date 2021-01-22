    // Convert a byte array to an Object
    public static Object ByteArrayToObject(byte[] arrBytes)
    {
    	using (var memStream = new MemoryStream())
    	{
    		var binForm = new BinaryFormatter();
    		memStream.Write(arrBytes, 0, arrBytes.Length);
    		memStream.Seek(0, SeekOrigin.Begin);
    		var obj = binForm.Deserialize(memStream);
    		return obj;
    	}
    }
 
