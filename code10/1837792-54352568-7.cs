    private void Browse_Click(object sender, EventArgs e)
    {
        string userFileName = string.Empty;
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            ofd.RestoreDirectory = true;
            ofd.Filter = "CSV Files|*.csv|Excel '97-2003|*.xls|Excel 2007-2019|*.xlsx";
            if (ofd.ShowDialog(this) == DialogResult.OK)
                userFileName = ofd.FileName;
        }
        
        if (userFileName.Length == 0) return;
        this.dataGridView1.DataSource = GetData(userFileName);
    }
    private DataTable GetData(string userFileName)
    {
        string dirName = Path.GetDirectoryName(userFileName);
        string fileName = Path.GetFileName(userFileName);
        string fileExtension = Path.GetExtension(userFileName);
        string connection = string.Empty;
        string query = string.Empty;
        switch (fileExtension)
        {
            case ".xls":
                connection = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={userFileName};" +
                               "Extended Properties=\"Excel 8.0; HDR=Yes; IMEX=1\"";
                query = "SELECT * FROM [Sheet1$]";
                break;
            case ".xlsx":
                connection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={userFileName};" +
                               "Extended Properties=\"Excel 12.0; HDR=Yes; IMEX=1\"";
                query = "SELECT * FROM [Sheet1$]";
                break;
            case ".csv":
                connection = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dirName};" +
                               "Extended Properties=\"text; HDR=Yes; IMEX=1; FMT=Delimited\"";
                query = $"SELECT * FROM {fileName}";
                break;
        }
        return FillData(connection, query);
    }
    private DataTable FillData(string conString, string query)
    {
        var dt = new DataTable();
        using (var con = new OleDbConnection(conString))
        using (var adapter = new OleDbDataAdapter(query, con))
        {
            adapter.Fill(dt);
        };
        return dt;
    }
