    static void Main(string[] args)
    {
        myList.Add(new { Test = "test", Test2 = "test2" });
        myList.Add(new { Test = "test", Test2 = "test2" });
        myList.Add(new { Test = "test1", Test2 = "test2" });
        // I need to pass a dynamic list of expression like:
        GenerateGroup(x => new { x.Test, x.Test2 } ); //groups myList by Test and Test2
        GenerateGroup(x => x.Test2); //groups myList in a single group
    }
    private static void GenerateGroup(Func<dynamic, object> groupper)
    {
        var groupped = myList.GroupBy(groupper);
    }
