    static async Task Main(string[] args)
    {
    	var a = Program<int>.TransactionOperation1();
    	var b = Program<int>.TransactionOperation2();
    	await Task.Run(async() =>
    	{
    	Console.ReadLine();
    	await Program<int>.TriggerTransaction(5);
    	});
    	
    	if (!File.Exists("D:\\data.txt"))
    	{
    	File.Create("D:\\data.txt");
    	}
    	
    	using (FileStream stream = new FileStream("D:\\data.txt", FileMode.Append, FileAccess.Write))
    	{
    		int sum = await a + await b;//thread wont pass this line when tasks are set.		
    		var bytes = Encoding.UTF8.GetBytes(sum.ToString());		
    		stream.Write(bytes, 0, bytes.Length);
    	}
    	
    	Console.WriteLine(await a + await b);
    }
    
    class Program<T>
    {
    	public static Task<T> TransactionOperation1()
    	{
    		var tcs = new TaskCompletionSource<T>();
    		tasks.Add(tcs);
    		return tcs.Task;
    	}
    	
    	public static Task<T> TransactionOperation2()
    	{
    		var tcs = new TaskCompletionSource<T>();
    		tasks.Add(tcs);
    		return tcs.Task;
    	}
    
    	public static async Task<T> ExecuteTransactionOnDB(T t)
    	{
    		return await Task.FromResult(t);
    	}
    
    	public static async Task TriggerTransaction(T t)
    	{
    		T value = await ExecuteTransactionOnDB(t);
    		
    		foreach (var item in tasks)
    		{
    			item.SetResult(value);
    		}
    	}
    	
    	public static List<TaskCompletionSource<T>> tasks = new List<TaskCompletionSource<T>>();
    	
    }
