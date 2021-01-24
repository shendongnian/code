    public static List<String> processData(string fileName)
    {
    	var lines = File.ReadAllLines(fileName);
    	
    	var values = lines.Select(x => 
    	{
    		var readsplitted = x.Split(',');
    		return new { Name = readsplitted[0], Verison = int.Parse(readsplitted[2].Replace("v", string.Empty))};	
    	});
    	
    	var maxValue= values.Max(x => x.Verison);
    	
    	return values.Where(v => v.Verison == maxValue)
    	.Select(v => v.Name)
    	.ToList();	
    }
    
    static void Main(string[] args)
    {
    	try
    	{
    		List<String> retVal = processData(@"D:\output.txt");
    	}
    	catch (IOException ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
