    public static List<string> GetImportedFileList()
    {
    List<string> ImportedFiles = new List<string>();
        using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Documents and Settings\js91162\Desktop\CMMData.db3"))
        {
            connect.Open();
            using (SQLiteCommand fmd = connect.CreateCommand())
            {
                SQLiteCommand sqlComm = new SQLiteCommand(@"SELECT DISTINCT FileName FROM Import");
                SQLiteDataReader r = sqlComm.ExecuteReader();
                while (r.Read()) 
                {
                    ImportedFiles.Add(Convert.ToString(r["FileName"]));
                                            
                }
        }
    }
    return ImportedFiles;
        }
