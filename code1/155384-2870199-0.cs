    protected void Page_Load(object sender, EventArgs e)
    {
        List<List<string>> data = GetListFromCsv(this.DataFile);
        Table table = GetHtmlTable(data);
        this.plcDataTable.Controls.Add(table);
    }
    // get list of 'rows' (event though each row is just a list of strings)
    public static List<List<string>> GetListFromCsv(string file)
    {
        String[] csvData = File.ReadAllLines(file);
        List<string> rowList = new List<string>();
        if (csvData.Length == 0)
        {
            throw new Exception("CSV File Appears to be Empty");
        }
        var rows = (from r in csvData
                    select r.Split(',').ToList()
                   ).ToList();
        return rows;
    }
    private Table GetHtmlTable(List<List<string>> dataTable)
    {
        List<TableRow> rows = new List<TableRow>();
        rows.AddRange(GetListOfRows(dataTable));
        Table table = new Table();
        table.Rows.AddRange(rows.ToArray());
        return table;
    }
    // convert the 'rows' to real rows.
    public static IEnumerable<TableRow> GetListOfRows(List<List<string>> table)
    {
        var rows = new List<TableRow>();
        foreach (var row in table
        {
            rows.Add(GetTableRow(row));
        }
        return rows;
    }
    private static TableRow GetTableRow(List<string> rows)
    {
        TableRow row = new TableRow();
        row.Cells.Add(GetColumnOneCell(rows));
        row.Cells.AddRange(GetValueCells(rows).ToArray());
        return row;
    }
