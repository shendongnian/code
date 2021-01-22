          public static dynamic  getCustomer() 
    { 
        ..... 
        var x = from c in customers 
                select new {Fname = c.FirstName}; 
 
        return x; 
    } 
    static void Main(string[] args) 
    { 
        dynamic x = getCustomer(); 
        Console.WriteLine(Enumerable.First(x).Fname); 
        Console.ReadKey(); 
    } 
