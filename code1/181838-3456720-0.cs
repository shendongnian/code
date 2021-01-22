    var groups = myList.Select (text => 
    new
     { 
      FirstNum = int.Parse(text.Split('_')[0]), 
      SecondNum = int.Parse(text.Split('_')[1])
     })
    .GroupBy(a => a.FirstNum);
    
    
    foreach(var group in groups.OrderBy(g => g.Key))
    {
      int min = group.Min( a => a.SecondNum);
      int max = group.Max( a => a.SecondNum);
    
      for(int i=min; i<=max; i++)
        yield return string.Format ("mapPart_{0}_{1}", group.key, i);
    
    }
