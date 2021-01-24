        public DataTable GetNonNumericDataInSpecifiedColumn(string table, string col)
        {
            string query = "SELECT rowid, * FROM " + table + " WHERE [" + col + "] GLOB '*[^0123456789.-]*'";
            return FetchDTFromDatabase(query);
        }
        public DataTable GetDecimalDataInSpecifiedColumn(string table, string col)
        {
            string query = "SELECT rowid, * FROM " + table + " WHERE [" + col + "] NOT GLOB '*[a-zA-Z]*' AND [" + col + "] GLOB '*.*';";
            return FetchDTFromDatabase(query);
        }
        public string GetActualDataBaseStringValueInANumericColumn(string table, int rowPrimaryKey, string colName)
        {
            string query = "SELECT [" + colName + "] FROM " + table + " WHERE rowid=" + rowPrimaryKey + ";";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    string value = reader.GetString(0);
                    return value;
                }
            }
        }
        public string GetActualDataBaseRealValueInAnIntegerColumn(string table, int rowPrimaryKey, string colName)
        {
            string query = "SELECT [" + colName + "] FROM " + table + " WHERE rowid=" + rowPrimaryKey + ";";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    double value = reader.GetDouble(0);
                    return value.ToString();
                }
            }
        }
        private DataTable FetchDTFromDatabase(string query)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
