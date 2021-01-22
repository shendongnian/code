    public void BackupDatabase(SqlConnection con, string databaseName, string backupName, string backupDescription, string backupFilename) {
        con.FireInfoMessageEventOnUserErrors = true;
        con.InfoMessage += OnInfoMessage;
        con.Open();
        using(var cmd = new SqlCommand(string.Format(
            "backup database {0} to disk = {1} with description = {2}, name = {3}, stats = 1",
            databaseName,
            backupFilename,
            backupDescription,
            backupName), con)) {
            cmd.ExecuteNonQuery();
        }
        con.Close();
        con.InfoMessage -= OnInfoMessage;
        con.FireInfoMessageEventOnUserErrors = false;
    }
    private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e) {
        foreach(SqlError info in e.Errors) {
            if(info.Class > 10) {
                // TODO: treat this as a genuine error
            } else {
                // TODO: treat this as a progress message
            }
        }
    }
