	void Main()
	{
		var inputFilePath = @"c:\temp\bigfile.zip";
		var convertedDataPath = ConvertToBase64TempFile(inputFilePath);
		Console.WriteLine($"Take a look in {convertedDataPath} for your converted data");
	}
	
	//inputFilePath = where your source file can be found.  This is not impacted by the below code
	//bufferSizeInBytesDiv3  = how many bytes to read at a time (divided by 3); the larger this value the more memory is required, but the better you'll find performance.  The Div3 part is because we later multiple this by 3 / this ensures we never have to deal with remainders (i.e. since 3 bytes = 4 base64 chars)
	public string ConvertToBase64TempFile(string inputFilePath, int bufferSizeInBytesDiv3 = 1024)
	{
		var tempFilePath = System.IO.Path.GetTempFileName();
		using (var fileStream = File.Open(inputFilePath,FileMode.Open))
	    {
	        using (var reader = new BinaryReader(fileStream))
			{
				using (var writer = new StreamWriter(tempFilePath))
	        	{
					byte[] data;
        	        while ((data = reader.ReadBytes(bufferSizeInBytesDiv3 * 3)).Length > 0)
					{
						writer.WriteLine(System.Convert.ToBase64String(data)); //NB: using WriteLine rather than Write; so when consuming this content consider removing line breaks (I've used this instead of write so you can easily stream the data in chunks later)
					}
	        	}
			}
	    }
		return tempFilePath;
	}
