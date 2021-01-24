    try
    {
    	using (Stream stream = new FileStream("1.docx", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
    	{
    		// Here you can copy your file
    		// then rename the copied file
    		// rename the file
    		int i = 1;
    		using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
    		{
    			writer.Write(""); // truncate the file, making it unusable to others
    		}
    	}
    	while (true)
    	{
    		try
    		{
    			File.Delete("1.docx");
    		}
    		catch 
    		{
    		}
    	}
    }
    catch (Exception ex)
    {
    	MessageBox.Show("File is in use!! Close it and try again");
    	return;
    }
