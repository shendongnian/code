    var group1 = new string[][] { new[] { "A", "B" }, new[] { "C", "D" }, new[] { "X", "Y" } };
    var group2 = new string[][] { new[] { "X", "Y", "Z" }, new[] { "A" }, new[] { "C", "D" }, new[] { "M", "N" } };
    
    // For each array in group1, check if it has matching array in group2, if
    // it does, merge, otherwise just take the array as is.
    var group1Join = from g1 in group1
                     let match = group2.SingleOrDefault(g2 => g1.Intersect(g2).Any())
                     select match != null ? g1.Union(match) : g1;
    
    // Take all the group2 arrays that don't have a matching array in group1 and
    // thus were ignored in the first query.
    var group2Leftovers = from g2 in group2
                          where !group1.Any(g1 => g2.Intersect(g1).Any())
                          select g2;
    
    var all = group1Join.Concat(group2Leftovers);
