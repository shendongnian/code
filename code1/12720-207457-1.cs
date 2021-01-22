    for (int idx = list.Count-1; idx >= 0; idx--)
    {
        if (list[idx].Rating < 1000)
        {
            list.RemoveAt(idx);
        }
    }
