    public static void GenerateColumns(this DataGrid, IEnumerable<ColumnSchema> columns)
    {
        dataGrid.Columns.Clear();
        int index = 0;
        foreach (var column in columns)
        {
            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = column.Name,
                Binding = new Binding(string.Format("[{0}]", index++))
            });
        }
    }
    // E.g. myGrid.GenerateColumns(schema);
