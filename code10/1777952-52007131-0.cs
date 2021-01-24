    Public DataTable d = new DataTable(); <---- here
    private void btnCSVgetter_Click(object sender, EventArgs e)
    {
        emptyDataGrid();
        OpenFileDialog csv = new OpenFileDialog();
        csv.Title = "Select CSV to Upload";
        csv.DefaultExt = "*.csv";
        csv.Filter = "CSV files| *.csv";
        if (csv.ShowDialog() == DialogResult.OK)
        {
            string safeName = csv.SafeFileName;
            string filename = csv.FileName;
            string filedirectory = csv.FileName.Substring(0, filename.IndexOf(safeName));
            if (IsFileLocked(filename) == true) { MessageBox.Show("File is in use by another user, close and try again"); return; }
            OleDbConnection con = new OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Text;HDR=YES;FMT=Delimited\"", filedirectory));
            OleDbCommand cmd = new OleDbCommand(String.Format("select * from [" + safeName + "]"), con);
            con.Open();
            OleDbDataAdapter csvDA = new OleDbDataAdapter(cmd);
            DataTable d = new DataTable(); <----- here
            csvDA.Fill(d);
