    var testArray = new string[] { "??", "??", "FF", "5B", "??", "01", "??" }.ToList();
    if (testArray.First().Equals("??"))
        testArray.RemoveAt(0);
    if (testArray.Last().Equals("??"))
        testArray.RemoveAt(testArray.Count - 1);
