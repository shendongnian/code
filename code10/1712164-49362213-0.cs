    var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
    var list2 = new List<string>();
    for (int i = 0; i < list1.Count / 8; i++)
    {
        list2.Add(string.Concat(list1.Skip(i * 8).Take(8)));
    }
    // list2[0] = "12345678"
    // list2[1] = "910111213141516"
