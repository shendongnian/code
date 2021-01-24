    char Delimiter = '|';
    string[] Lines = File.ReadAllLines("[SomeFilePath]", Encoding.Default);
    List<string[]> FileRows = Lines.Select(line => 
        line.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries)).ToList();
    DataTable dt = new DataTable();
    dt.Columns.AddRange(FileRows[0].Select(col => new DataColumn() { ColumnName = col }).ToArray());
    FileRows.RemoveAt(0);
    FileRows.ForEach(row => dt.Rows.Add(row));
    dataGridView1.DataSource = dt;
