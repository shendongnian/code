    foreach (DataRow dr in dt.Rows)
    {
        cl1.Items.Add(new ListItem((string)dr["LD"], dr["ID"]+""));
        cl2.Items.Add(new ListItem((string)dr["LD"], dr["ID"]+""));
        cl2.Items.Add(new ListItem((string)dr["LD"], dr["ID"]+""));
    }
