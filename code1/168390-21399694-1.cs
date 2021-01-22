    d[0][0].a // out 1 from table 0 row 0
    d[1][1].b // out 59 from table 1 row 1
    // Created by Behnam Mohammadi And Saeed Ahmadian
    public string jsonMini(DataSet ds)
    {
        int t = 0, r = 0, c = 0;
        string stream = "[";
        for (t = 0; t < ds.Tables.Count; t++)
        {
            stream += "[";
            for (r = 0; r < ds.Tables[t].Rows.Count; r++)
            {
                stream += "{";
                for (c = 0; c < ds.Tables[t].Columns.Count; c++)
                {
                    stream += ds.Tables[t].Columns[c].ToString() + ":'" +
                              ds.Tables[t].Rows[r][c].ToString() + "',";
                }
                if (c>0)
                    stream = stream.Substring(0, stream.Length - 1);
                stream += "},";
            }
            if (r>0)
                stream = stream.Substring(0, stream.Length - 1);
            stream += "],";
        }
        if (t>0)
            stream = stream.Substring(0, stream.Length - 1);
        stream += "];";
        return stream;
    }
