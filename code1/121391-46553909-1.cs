    static void ReadCSV()
    {
    	using (var stream = new MemoryStream())
    	using (var reader = new StreamReader(stream))
    	using (var writer = new StreamWriter(stream))
    	using (var parser = new ChoCSVReader(reader))
    	{
    		writer.WriteLine("id,name");
    		writer.WriteLine("1,Carl");
    		writer.WriteLine("2,Mark");
    		writer.WriteLine("3,Tom");
    
    		writer.Flush();
    		stream.Position = 0;
    
    		foreach (dynamic dr in parser)
    		{
    			Console.WriteLine("Id: {0}, Name: {1}", dr.id, dr.name);
    		}
    	}
    }
