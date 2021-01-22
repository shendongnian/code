    private static byte[] ReadBinary(string fileName)
    {
    	byte[] binaryData = null;
    	using (FileStream reader = new FileStream(fileName,
    	  FileMode.Open, FileAccess.Read))
    	{
    		binaryData = new byte[reader.Length];
    		reader.Read(binaryData, 0, (int)reader.Length);
    	}
    	return binaryData;
    }
