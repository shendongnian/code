    var list1 = new List<int> { 1, 2, 3, 4, 5 };
    var list2 = new List<int> { 1, 3, 5 };
    var missing = list1.Except(list2).ToList();
    missing.ForEach(i => Console.Write("{0}\t", i));
    >> 2    4
