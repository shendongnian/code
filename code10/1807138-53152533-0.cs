    using (Stream stream = File.OpenRead(@"C:\Code\sharpcompress.rar"))
    {
    	var reader = ReaderFactory.Open(stream);
    	while (reader.MoveToNextEntry())
    	{
    		if (!reader.Entry.IsDirectory)
    		{
    			reader.WriteEntryToDirectory(@"C:\temp", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
    		}
    	}
    }
