    public static DataTable LoadCSV(FileInfo theFile)
        {   
            string sqlString = "Select * FROM [" + theFile.Name + "];";
            string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + theFile.DirectoryName + ";" + "Extended Properties='text;HDR=YES;'";
            DataTable theCSV = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                using (OleDbCommand comm = new OleDbCommand(sqlString, conn))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(comm))
                    {
                        adapter.Fill(theCSV);
                    }
                }
            }
            return theCSV;
        }
