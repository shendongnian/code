    public void ImportCsvFile(string filename)
{
    FileInfo file = new FileInfo(filename);
    using (OleDbConnection con = 
            new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
            file.DirectoryName + "\";
            Extended Properties='text;HDR=Yes;FMT=TabDelimited';"))
    {
        using (OleDbCommand cmd = new OleDbCommand(string.Format
                                  ("SELECT * FROM [{0}]", file.Name), con))
        {
            con.Open();
 
            // Using a DataReader to process the data
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Process the current reader entry...
                }
            }
            // Using a DataTable to process the data
            using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
            {
                DataTable tbl = new DataTable("MyTable");
                adp.Fill(tbl);
                foreach (DataRow row in tbl.Rows)
                {
                    // Process the current row...
                }
            }
        }
    }
