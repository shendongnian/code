    var arr = new List<double[]>();
    arr.Add(new double[] { 1, 2, 3});
    arr.Add(new double[] { 4, 3, 7 });
    arr.Add(new double[] { 7, 8, 9, 10 });
    arr.Add(new double[] { 11 });
  
    var longestArr = arr.OrderByDescending(a => a.Length).First();
    var result = longestArr.Select((_, i) => arr.Where(a => a.Length > i).Select(a => a[i]).ToArray()).ToList();
    foreach (var _ in result)
    {
       foreach (var element in _)
       {
          Console.Write(element + " ");
       }
       Console.WriteLine();
    }
