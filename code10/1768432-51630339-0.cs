    var list1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var list2 = new List<int>() { 40, 50, 60 };
    var position = 3;
    foreach (var value in list2)
    {
        if (position < list1.Count)
        {
            list1[position] = value;
        }
        else
        {
            list1.Add(value);
        }
    
        ++position;
    }
