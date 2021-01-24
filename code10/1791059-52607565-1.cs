    public static void Main(string[] args)
    {
        var items = new [] 
        { 
           new { Id = "1", Title = "ProcessId: 123"}, 
           new { Id = "4", Title = "ProcessId: 456"}, 
           new { Id = "7", Title = "ProcessId: 789"}, 
        }.ToList();
        
        // returns null, because the string "Title" doesn't contain the string "7"
        var res1 = items.Where("@0.Contains(\"7\")", new string[] {"Title"}).FirstOrDefault();     
        
        // works - returns the 3rd element of the array
        var res2a = items.Where("Title.Contains(@0)", new string[] {"ProcessId: 789"}).FirstOrDefault();                 
        var res2b = items.Where("Title.Contains(\"ProcessId: 789\")").FirstOrDefault();
    }
