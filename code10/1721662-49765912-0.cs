    using (StreamReader Reader = new StreamReader(File.Open(AccountsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
    {
    	string line;
    	int count = 0;
    	while ((line = Reader.ReadLine()) != null)
    	{
    		if (line == "Placeholder:Placeholder")
    		{
    			count++;
    		}
    	}
    }
