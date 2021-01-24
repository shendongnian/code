    char Delimiter = '|';
    string[] Lines = File.ReadAllLines("[SomeFilePath]", Encoding.Default);
    List<string[]> FileRows = Lines.Select(line => 
        line.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries)).ToList();
    DataTable dt = new DataTable();
    dt.Columns.AddRange(FileRows[0].Select(col => new DataColumn() { ColumnName = col }).ToArray());
    FileRows.RemoveAt(0);
    FileRows.Select(row => dt.Rows.Add(row)).ToList();
    dataGridView1.DataSource = dt;
