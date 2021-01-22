    struct headerIndexes 
    { 
        public int AccountNum{ get; set; } 
        public int other { get; set; } 
        public int items { get; set; } 
    } 
    static void Main(string[] args) 
    { 
 
        headerIndexes headers = new headerIndexes(); 
        headers.AccountNum = 1; 
        Console.WriteLine("Old val: {0}", headers.AccountNum); 
        object unboxedHeader=headers;
        foreach (var s in headers.GetType().GetProperties()) 
        { 
            if (s.Name == "AccountNum") 
                s.SetValue(unboxedHeader, 99, null); 
        } 
        Console.WriteLine("New val: {0}", headers.AccountNum); 
        Console.ReadKey(); 
    } 
