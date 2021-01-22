    foreach (DataColumn dc in dt.Columns)
    {
        bool deleteIt = true;
        foreach (StringDictionary sd in sdArray)
        {
            if (dc.ColumnName.Equals(sd["Name"]))
                deleteIt = false;
        }
        if (deleteIt)
            data.Columns.Remove(dc);
    }
