    int userInput = 4;
    // below, Enum.GetValues converts enum to array. We then convert the array to hashset.
    HashSet<int> validVals = new HashSet<int>((int[])Enum.GetValues(typeof(MyEnum)));
    // the following could be in a loop, or do multiple comparisons, etc.
    if (validVals.Contains(userInput))
    {
        // is valid
    }
