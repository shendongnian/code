    var ary = new double[] { 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 };
    
    var thresh = 3;
    var result = new List<int>();
    var list = new List<int>();
    
    for (var i = 0; i < ary.Length - 2; i++)
    {
       list.Add(i);
    
       if (ary[i] == ary[i + 1])
          continue;
    
       if (list.Count >= thresh)
          result.AddRange(list);
    
       list.Clear();    
    }
    
    if (list.Count >= thresh)
       result.AddRange(list);
    
    // write results
    foreach (var index in result)
       Console.WriteLine(index);
