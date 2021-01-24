    var list1 = new List<string> { "lets", "go", "visit", "houston", "texas" };
    var list2 = new List<string>();
    list2.AddRange(list1.Skip(3).Take(2 /* there is 2 elements from 3rd to 4th*/));
    // or
    list2.AddRange(list1.Skip(3));
