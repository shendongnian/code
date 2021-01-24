    byte[] byteArray;
    using (var targetStream = new MemoryStream())
    using (var writer = new StreamWriter(targetStream))
    using (var reader = new StreamReader(await provider.Contents[0].ReadAsStreamAsync()))
    {
    	while (!reader.EndOfStream)
    	{
            var line = reader.ReadLine();
            if(SomeCondition)
    		   writer.WriteLine(line);
    	}
        byteArray = targetStream.ToArray();
    }
