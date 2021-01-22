    var list3 = joined.ToList();
    // or
    var list3 = (from Item1 in list1
                 join Item2 in list2
                 on Item1.Id equals Item2.Id // join on some property
                 select new { Item1, Item2 }).ToList();
