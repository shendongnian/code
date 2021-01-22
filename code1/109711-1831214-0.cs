    foreach (string k in Dic1.Keys)
    {
        DataRow row = table.NewRow();
        row[0] = k;
        row[1] = Dic1[k];
        if (Dic2.ContainsKey(k))
            row[2] = Dic2[k];
        if (Dic3.ContainsKey(k))
            row[3] = Dic3[k];
    
        table.Rows.Add(row);
    }
