    private static void CountOccurances(List<string> inputList, string countFor) 
    {
        int result = 0;
        foreach (string s in inputList)
        {
            if (s == countFor)
            {
                result++;
            }
        }
        Console.WriteLine($"There are {result} occurrances of {countFor}.");
    }
