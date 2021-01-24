    using (SqlDataAdapter da = new SqlDataAdapter(cmdstring, con))
    using (DataTable dt = new DataTable())
    {
        da.Fill(dt);
    
        if (dt.Rows.Count != 0)
        {
            splitlst.Add(dt.Rows[0][0].ToString());//kunde
            splitlst.Add(dt.Rows[0][1].ToString());
            splitlst.Add(dt.Rows[0][2].ToString());
            splitlst.Add(dt.Rows[0][3].ToString());
            splitlst.Add(dt.Rows[0][4].ToString());
            splitlst.Add(dt.Rows[0][5].ToString());
        }
    }
