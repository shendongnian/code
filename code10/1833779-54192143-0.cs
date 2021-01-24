    var ary = new double[] { 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 };
    
    var result = new List<int>();
    var list = new List<int>();
    
    for (var i = 0; i < ary.Length-2; i++)
    {
       // add index 
       list.Add(i);
     
       // check if not equal to next index
       if (ary[i] != ary[i + 1])
       {
          // if above some threshold
          if (list.Count >= 3)
             result.AddRange(list); // add to results
    
          list.Clear(); // clear temp
       }
    }
    
    // check the last batch
    if (list.Count > 3)
       result.AddRange(list);
