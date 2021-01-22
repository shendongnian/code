    List<int>.Enumerator e = l.GetEnumerator();
    int p = 0, min = int.MaxValue, pos = -1;
    while (e.MoveNext())
    {
        if (e.Current < min)
        {
            min = e.Current;
            pos = p;
        }
        ++p;
    }
