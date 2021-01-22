    public void LoadCheckFiletoDatabase(string checkFilePath)
            {
                DataTable tempTable = GetDataTableFromCsv(checkFilePath);
    
                foreach (DataRow DataR in this.memDataTable.Columns)
                {
                    Dictionary<string, object> Dic = new Dictionary<string, object>();
                    foreach (DataColumn DataCol in this.memDataTable.Columns)
                    {
                        string field = DataCol.ColumnName.ToString();
                        object value = (string)DataR[DataCol].ToString();
                        Dic.Add(field, value);                   
                    }
                    using (SQLiteConnection sQLiteConnection = new SQLiteConnection("data source=" + databasepath))
                    {
    
                         using (SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection))
                         {
                            System.Data.SQLite.SQLiteHelper sQLiteHelper = new SQLiteHelper(sQLiteCommand);
                            sQLiteHelper.BeginTransaction();
                            sQLiteHelper.Insert(tempTable.TableName, Dic);
                         }
                    }    
                }
            public static DataTable GetDataTableFromCsv(string path)
            {
                string pathOnly = Path.GetDirectoryName(path);
                string fileName = Path.GetFileName(path);
    
                string sql = @"SELECT * FROM [" + fileName + "]";
    
                using(OleDbConnection connection = new OleDbConnection(
                          @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + 
                          ";Extended Properties=\"Text;HDR=" + "Yes" + "\""))
                using(OleDbCommand command = new OleDbCommand(sql, connection))
                using(OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Locale = CultureInfo.CurrentCulture;
                    adapter.Fill(dataTable);
                    dataTable.TableName = fileName.TrimEnd(new char[] {'.','c','s','v'});
                    return dataTable;
                }            
            }
