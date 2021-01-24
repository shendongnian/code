    // O(N)
    var dictOld = ae_alignedPartners_olds
      .GroupBy(p => p.ObjectID) // ObjectID should be a int, string or provide good GetHashCode()
      .ToDictionary(chunk => chunk.Key,
                    chunk => chunk.First());
    // O(N)
    var dictNew = ae_alignedPartners_news
      .GroupBy(p => p.ObjectID) 
      .ToDictionary(chunk => chunk.Key,
                    chunk => chunk.First());
    // O(N)
    foreach (var item in IDSIntersections)
    {
       // O(1) : no loops when finding value by key in dictionary
       var itemOld = dictOld[item];      
       var itemNew = dictNew[item];
       ... 
