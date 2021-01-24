    public List<string> GetUserNames()
    {
        string CommandText = "SELECT Name FROM User";
        using (SQLiteConnection conn = new SQLiteConnection(EmployeeComboFills.ecbconn()))
        using (SQLiteCommand cmd = new SQLiteCommand(CommandText, conn))
        {
            conn.Open();
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(dt);
            return dt.Rows
                .Cast<DataRow>()
                .Select(dr => dr["Name"].ToString())
                .ToList();
        }
    }
