    static async Task Main(string[] args)
    {
    	var a = Program.TransactionOperation1(5);
    	var b = Program.TransactionOperation1(5);
    	
    	Console.ReadLine();
    	
        var taskResults  = await Task.WhenAll(a,b);
    	
    	
    	dynamic finalResult = 0;
    	
    	foreach(var t in taskResults)
    		finalResult += t;
    	
    
    	if (!File.Exists("D:\\data.txt"))
    	{
    		File.Create("D:\\data.txt");
    	}
    
    	using (FileStream stream = new FileStream("D:\\data.txt", FileMode.Append, FileAccess.Write))
    	{
    		var bytes = Encoding.UTF8.GetBytes(finalResult.ToString());
    		stream.Write(bytes, 0, bytes.Length);
    	}
    
    	Console.WriteLine(finalResult);
    }
    
    class Program
    {
    	public static Task<dynamic> TransactionOperation1(dynamic val)
    	{
    		return Task<dynamic>.Run(() => val);
    	}
    
    	public static Task<dynamic> TransactionOperation2(dynamic val)
    	{
    		return Task<dynamic>.Run(() => val);
    	}
    
    }
