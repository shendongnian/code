    var rangeToComment = new Dictionary<NumRange, string>
    {
        {new NumRange(3,5), "The number 4."},
        {new NumRange(0, 10),"Single digit natural numbers"},
        {new NumRange(int.MinValue,int.MaxValue),"Integers"}
    };
    foreach (int number in Enumerable.Range(0, 100))
    {
        var tightestRange = rangeToComment.Where(kvp => kvp.Key.Contains(number))
                                          .OrderBy(kvp => kvp.Key.Size)
                                          .First();
        Console.WriteLine("{0}: {1}", number, tightestRange.Value);
    }
