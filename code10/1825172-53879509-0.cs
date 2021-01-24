    var testArray = new string[] { "??", "??", "FF", "5B", "??", "01", "??" }.ToList();
    if (testArray.First().Equals("??"))
        testArray = testArray.GetRange(1, testArray.Count - 1).ToList();
    if (testArray.Last().Equals("??"))
        testArray = testArray.GetRange(0, testArray.Count - 1).ToList();
