    static void Main()
    {
    	List<string> files = new List<string>() { "file1", "file2" };
    	foreach (var file in files)
    	{
    		Work(file);
    	}
    	Console.ReadLine();
    }
    
    private static async void Work(string file)
    {
    	var data = await LoadFromFile(file);
    	await ProcessData(data);
    }
    
    private static async Task ProcessData(string data)
    {
    	await Task.Delay(5000);
    	Console.WriteLine($"Processed {data}");
    }
    
    private static async Task<string> LoadFromFile(string file)
    {
    	await Task.Delay(3000);
    	Console.WriteLine($"Loaded {file}");
    	return file.Replace("file", "data");
    }
