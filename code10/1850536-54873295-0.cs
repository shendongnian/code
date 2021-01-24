    //My test data
    var list = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();
    //Create DataTable
    var columnsCount = 4;
    var datatable = new DataTable();
    for (int i = 0; i < columnsCount; i++)
        datatable.Columns.Add($"C{i + 1}");
    //Convert List<string> to DataTable having 4 columns
    list.Select((x, i) => new { Value = x, Index = i })
        .GroupBy(x => x.Index / columnsCount).ToList()
        .ForEach(x => datatable.Rows.Add(x.Select(m => m.Value).Cast<object>().ToArray()));
    //Show data in DataGridView
    dataGridView1.DataSource = datatable;
