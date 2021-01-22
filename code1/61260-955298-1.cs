    using (IEnumerator<string> iterator = myList.GetEnumerator())
    {
        if (!iterator.MoveNext())
        {
            throw new WhateverException("Empty list!");
        }
        string first = iterator.Current;
    }
