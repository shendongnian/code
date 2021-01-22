    foreach (string c in v)
    {
        long index = GetIndexForCoord(c);
        m_dic.Add(index, c);
        m_indexes.Add(index);
    }
    
