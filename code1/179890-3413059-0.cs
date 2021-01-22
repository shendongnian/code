    List<int> list = new List<int>();
    
    while (sLeft.Count > 0 && sRight.Count > 0)
    {
        if (sLeft[0] <= sRight[0])
        {
            list.Add(sLeft[0]);
            sLeft.RemoveAt(0);
        }
        else
        {
            list.Add(sRight[0]);
            sRight.RemoveAt(0);
        }
    }
    // one of these two is already empty; the other is in sorted order...
    list.AddRange(sLeft);
    list.AddRange(sRight);
    return list;
