    List commonElements = new List<string>();
    foreach (var smallString in SmallList)
    {
       if (large.Any(x => x.Contains(smallString)))
       {
           // Add to common elements
           commonElements.Add(smallString);
       }
    }
