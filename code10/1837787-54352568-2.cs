    string userFileName = string.Empty;
    using (OpenFileDialog ofd = new OpenFileDialog())
    {
        ofd.RestoreDirectory = true;
        ofd.Filter = "CSV Files (*.csv)|*.csv";
        if (ofd.ShowDialog(this) == DialogResult.OK)
            userFileName = ofd.FileName;
    }
    if (userFileName.Length == 0) return;
    string dirName = Path.GetDirectoryName(userFileName);
    string fileName = Path.GetFileName(userFileName);
    string connectionString = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dirName};" +
                                "Extended Properties=\"text; HDR=Yes; IMEX=1; FMT=Delimited\";";
    DataSet dataSet = new DataSet();
    DataTable dataTable = new DataTable();
    using (OleDbConnection con = new OleDbConnection(connectionString))
    {
            string query = $"SELECT * FROM {fileName}";
        con.Open();
        OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
        adapter.Fill(dataTable);
        dataSet.Tables.Add(dataTable);
    };
