    public void FillTable()
    {
       var res = new DataTable();
       res.Columns.Add(new DataColumn() { ColumnName = "Color" });
       res.Columns.Add(new DataColumn() { ColumnName = "Is it Cool?" });
       res.Rows.Add(new object[]{ "Red", "Yes" });
       res.Rows.Add(new object[]{ "Pink", "Absolutely not" });
       TableResult = res;
    }
