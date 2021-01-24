    DataTable dt = new DataTable();
    dt.Columns.AddRange(new DataColumn[3]
    {
        new Datacolumn("column1", typeof(string)),
        new DataColumn("column2", typeof(double)),
        new DataColumn("column3", typeof(DateTime))
    });
