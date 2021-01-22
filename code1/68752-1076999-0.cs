    //in the code somewhere above:
    string tempDirectory = Environment.GetEnvironmentVariable("TEMP");
    string createPath = tempDirectory + "\\" + Path.GetFileName(entry.Name);
    
    
    //my missing piece..
    //Extract file into a temp directory somewhere
    FileStream streamWriter = File.Create(createPath);
    
    int size = 2048;
    byte[] data = new byte[2048];
    while (true)
    {
    	size = inStream.Read(data, 0, data.Length);
    	if (size > 0)
    	{
    		streamWriter.Write(data, 0, size);
    	}
    	else
    	{
    		break;
    	}
    }
    
    streamWriter.Close();
