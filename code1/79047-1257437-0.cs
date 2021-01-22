    var lst = new List<int>() { 1, 2, 3, 4, 5 };
    lst[0].Dump(); // 1
    lst.Dump(); // 1, 2, 3, 4, 5
    lst[0] = 2;
    lst.Dump(); // 2, 2, 3, 4, 5
