    if (subsetList.Count > 0)
    {
        using(IEnumerator<T2> subset = subsetList.GetEnumerator())
        {
            subset.MoveNext();
            T2 subitem = subsetList.Current;
            foreach(T1 item in supersetList)
            {
                while (item.A > subitem.A &&
                       subset.MoveNext())
                {
                    subitem = subset.Current;
                }
                if (item.A == subitem.A)
                {
                    // Modify item here.
                }
            }
        }
    }
