    var longestArrLength = arr.Max(a => a.Length);
    var result2 = new List<double[]>(arr.Count);
    for (int i = 0; i < longestArrLength; i++)
    {
       result2.Add(arr.Where(a => a.Length > i).Select(a => a[i]).ToArray());
    }
