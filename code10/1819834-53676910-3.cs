    static void Main()
    {
        var comparisonList = new List<string>
        {
            "Username",
            "Password",
            "SampleRequestValue",
            "SampleComplexRequest",
            "SampleComplexRequest.SampleTestBValue",
            "SampleComplexRequest.SampleTestAValue",
        };
        // Add items in an "unorderd" order
        var items = new SortedDictionary<string, string>(new ListComparer(comparisonList))
        {
            {"Password", "LetMeIn"},
            {"Username", "JohnDoe"}
        };
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Key} = {item.Value}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
