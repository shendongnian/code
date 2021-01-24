    static void Main()
    {
    	List<string> files = new List<string>() { "file1", "file2" };
    	Parallel.ForEach(files, (file) =>
    	{
    		var data = LoadFromFile(file);
    		ProcessData(data);
    	});
    	Console.ReadLine();
    }
    
    private static void ProcessData(string data)
    {
    	Thread.Sleep(3000);
    	Console.WriteLine($"Processed {data}");
    }
    
    private static string LoadFromFile(string file)
    {
    	Thread.Sleep(5000);
    	Console.WriteLine($"Loaded {file}");
    	return file.Replace("file", "data");
    }
