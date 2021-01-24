    string sqliteConnectionString = "Data Source=PATH OF MY SQLITE DATABSE"
    string query = "SELECT * FROM employee WHERE id_employee = x";
        
    Dictionary<string, string> myemployeeX = new Dictionary<string, string>();
        DataTable result = new DataTable();
        SQLiteConnection db = DatabaseConnection(SqliteConnString);
        SQLiteCommand cmd = new SQLiteCommand(query, db);
        db.Open();
        DataTable result = new DataTable();
        SQLiteDataAdapter adap = new SQLiteDataAdapter(cmd);
        adap.Fill(result);
        foreach(DataRow row in result.Rows) {
            foreach(DataColumn clmn in result.Columns) {
                myemployeeX.Add(clmn.ColumnName, row[clmn.ColumnName]);
            }
        }
        db.Close();
