    var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }.AsEnumerable();
    var list2 = new List<string>();
    var i = 0;
    var nextValue = new StringBuilder();
    foreach (var integer in list1)
    {
        nextValue.Append(integer);
        i++;
        if (i != 0 && i % 8 == 0)
        {
            list2.Add(nextValue.ToString());
            nextValue.Clear();
        }
    }
    // could add remaining items if count of list1 is not a multiple of 8
    // if (nextValue.Length > 0)
    // {
    //     list2.Add(nextValue.ToString());
    // }
