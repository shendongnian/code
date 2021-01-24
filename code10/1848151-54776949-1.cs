    private static void Main()
    {
        var testStrings = new List<string>
        {
            "hello", "Hello", "HELLO", "hELLO"
        };
        var sample = "Hello";
        foreach (var testString in testStrings)
        {
            var result = sample.EqualsCaseExceptFirst(testString);
            Console.WriteLine($"{sample} == '{testString}'  :  {result}");
        }
        Console.WriteLine("----------");
        sample = "HELLO";
        foreach (var testString in testStrings)
        {
            var result = sample.EqualsCaseExceptFirst(testString);
            Console.WriteLine($"{sample} == '{testString}'  :  {result}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
