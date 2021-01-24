    static List<string> itemCollection = new List<string>();
    
    static void Main(string[] args)
    {
    
    	for (int i = 0; i < 10000000; i++)
        {
    		itemCollection.Add(i.ToString());
        }
    
        var watch = new Stopwatch();
        watch.Start();
    
        Console.WriteLine(CheckIdExists(580748));
        watch.Stop();
        Console.WriteLine($"Took {watch.ElapsedMilliseconds}");
    
        var watch1 = new Stopwatch();
        watch1.Start();
    
        Console.WriteLine(CheckIdExists1(580748));
        watch1.Stop();
        Console.WriteLine($"Took {watch1.ElapsedMilliseconds}");
    
        Console.ReadLine();
    }
    
    public static bool CheckIdExists(int searchId)
    {
        return itemCollection.Any(item => item.Equals(ConvertToString(searchId)));
    }
    
    public static bool CheckIdExists1(int searchId)
    {
        string sId =ConvertToString(searchId);
    
        return itemCollection.Any(item => item.Equals(sId));
    }
    
    public static string ConvertToString(int input)
    {
        return Convert.ToString(input, CultureInfo.InvariantCulture);
    }
