    public static void Test(Version version)
    {
       Console.WriteLine("is a version");
    }
    public static void Test(FormatException formatException)
    {
       Console.WriteLine("is a formatException");
    }
    static void Main(string[] args)
    {
    
       var list = new List<object>();
       list.Add(new Version());
       list.Add(new FormatException());
    
       foreach (var item in list)
          Test((dynamic)Convert.ChangeType(item, item.GetType())); 
    }
