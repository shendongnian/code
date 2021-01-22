    public static List<string> GetImportedFileList()
        {
            List<string> ImportedFiles = new List<string>();                        
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Documents and Settings\js91162\Desktop\CMMData.db3"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT FileName FROM Import";
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read()) 
                    {
                        string FileNames = (string)r["FileName"];
    
                        ImportedFiles.Add(FileNames);
                    }                    
    
                    connect.Close();
            }
        }
        return ImportedFiles;
    }
