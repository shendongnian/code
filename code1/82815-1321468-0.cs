    bool isOdd = false; 
    var sums = 1234567
        .ToString()
        .Select(x => Char.GetNumericValue(x))
        .GroupBy(x => isOdd = !isOdd)
        .Select(x => new { IsOdd = x.Key, Sum = x.Sum() });
    
    foreach (var x in sums)
        Console.WriteLine("Sum of {0} is {1}", x.IsOdd ? "odd" : "even", x.Sum);
