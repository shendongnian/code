    const int SomeTable_SomeColumn = 0;
    DataTable dt = new DataTable();
    if(dt.Columns.Contains(SomeTable_SomeColumn))
    {
        object o = dt.Rows[0][SomeTable_SomeColumn];
    }
