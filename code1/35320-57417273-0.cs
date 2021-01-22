        /// <summary>
        /// ConnectToTable
        /// </summary>
        /// <param name="pFullPath">Full path to .DB file</param>
        /// <param name="pTableName">Name of table to load</param>
        public static void ConnectToTable(string pFullPath, string pTableName)
        {
            OleDbConnection _ParadoxConnection = new OleDbConnection();
            StringBuilder ConnectionString = new StringBuilder("");
            ConnectionString.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;");
            ConnectionString.Append(@"Extended Properties=Paradox 7.x;");
            ConnectionString.Append(string.Format(@"Data Source={0}", pFullPath));
            _ParadoxConnection.ConnectionString = ConnectionString.ToString();
            _ParadoxConnection.Open();
            using (OleDbDataAdapter da = new OleDbDataAdapter(
                string.Format("SELECT * FROM {0};", pTableName)
                , _ParadoxConnection))
            {
                DataTable tab = new DataTable
                {
                    TableName = pTableName
                };
                da.Fill(tab);
                //tab now contains a data
                //Get the column name
                foreach(DataColumn col in tab.Columns)
                {
                    Console.WriteLine(col.ColumnName);
                }
                //do the rows
                foreach (DataRow row in tab.Rows)
                {
                    foreach(var item in row.ItemArray)
                    {
                        //write each row value
                    }
                }
            }
        }
