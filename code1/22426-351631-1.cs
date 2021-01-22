    DataSet ds = new DataSet();
    ds.Tables.Add(new DataTable());
    ds.Tables[0].Columns.Add("column_1", typeof(string));
    ds.Tables[0].Columns.Add("column_2", typeof(int));
    ds.Tables[0].Columns.Add("column_4", typeof(string));
    ds.Tables[0].Columns.Add("column_3", typeof(string));
    //set column 3 to be before column 4
    ds.Tables[0].Columns[3].SetOrdinal(2);
