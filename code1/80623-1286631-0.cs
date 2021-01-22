    public DataTable CreateTable(ICollection items)
    {
        DataTable table = new DataTable();
        table.Columns.Add("Column1", typeof(int));
        table.Columns.Add("Column2", typeof(string));
        foreach (Item item in items)
        {
            DataRow row = table.NewRow();
            row["Column1"] = item.Column1;
            row["Column2"] = item.Column2;
            table.Rows.Add(row);
        }
        return table;
    }
