    foreach (string c in v)
    {
        long index = GetIndexForCoord(c);
        if(!m_dic.ContainsKey(index))
        {
            m_dic.Add(index, c);
            m_indexes.Add(index);
        }
    }
    
