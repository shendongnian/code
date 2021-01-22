    var myList = new List<int[]>
    {
        new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 }
    };
    var sums =
        from array in myList
        from valueIndex in array.Select((value, index) => new { Value = value, Index = index })
        group valueIndex by valueIndex.Index into indexGroups
        select indexGroups.Select(indexGroup => indexGroup.Value).Sum()
    foreach(var sum in sums)
    {
        Console.WriteLine(sum);
    }
    // Prints:
    //
    // 11
    // 22
    // 33
    // 44
    // 55
    // 66
    // 77
    // 88
    // 99
