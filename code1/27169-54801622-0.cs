    IEnumerable<string> myStrings = new List<string>() { "1", "2", "3", "4", "5" };
    IEnumerable<int> convertedToInts = myStrings.Map(s => int.Parse(s));
    IEnumerable<int> filteredInts = convertedToInts.Filter(i => i <= 3); // Keep 1,2,3
    int sumOfAllInts = filteredInts.Reduce((sum, i) => sum + i); // Sum up all ints
    Assert.Equal(6, sumOfAllInts); // 1+2+3 is 6
