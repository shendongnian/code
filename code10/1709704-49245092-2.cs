    string[] array1 = { "a", "b", "b", "b", "c", "d" };
    string[] array2 = { "y", "b",  "c", "h", "f" };
    var grpArray1 = array1.GroupBy(a => a)
                     .Select(grp => new { item = grp.Key, count = grp.Count() });
    var grpArray2 = array2.GroupBy(a => a)
                     .Select(grp => new { item = grp.Key, count = grp.Count() });
    array1 = grpArray1.Select(a =>
                   {
                    var bCount = array2.Count(x => x.Equals(a.item));
                    return new { item = a.item, finalCount = a.count - bCount };
                   })
                  .Where(a => a.finalCount > 0)
                  .SelectMany(a => Enumerable.Repeat(a.item, a.finalCount))
                  .ToArray();
    array2 = grpArray2.Select(a =>
                  {
                   var bCount = array1.Count(x => x.Equals(a.item));
                   return new { item = a.item, finalCount = a.count - bCount };
                  })
                 .Where(a => a.finalCount > 0)
                 .SelectMany(a => Enumerable.Repeat(a.item, a.finalCount))
                 .ToArray();
    Console.WriteLine("-->array1:");
    foreach (var item in array1)
        Console.WriteLine(item);
    Console.WriteLine("-->array2:");
    foreach (var item in array2)
        Console.WriteLine(item);
