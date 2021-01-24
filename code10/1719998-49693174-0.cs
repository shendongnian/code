    try
    {
        var filePath = Path.GetFullPath(openAirtimeFile.FileName);
        bool FoundTango = false;
        foreach (var line in File.ReadAllLines(filePath))
        {
            var thisLine = line;//.Trim();
                if (thisLine.StartsWith("Tango", StringComparison.OrdinalIgnoreCase))
                {
                     FoundTango = true;
                     continue; //Tango has been found, skip to next iteration
                }
                
                if (FoundTango)
                {                        
                    DataTable dt = new DataTable();
                    string[] col = line.Split(',');
                    foreach (string s in col)
                    {
                        dt.Columns.Add(s, typeof(string));
                    }
                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] row = line.Split(',');
                        dt.Rows.Add(row);
                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
          }
