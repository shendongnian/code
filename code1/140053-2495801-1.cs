    dic = new Dictionary<int, int> { 
        { 1, 2 },
        { 3, 4 }
    };
    // translated to:
    dic = new Dictionary<int, int>();
    dic.Add(1, 2);
    dic.Add(3, 4);
