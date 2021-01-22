    string line;
    // Read the file and display it line by line.
    using (StreamReader file = new StreamReader(@"c:\yourfile.txt"))
    {
    	while ((line = file.ReadLine()) != null)
    	{    
    		Console.WriteLine(line);
            // do your processing on each line here
    	}
    }
