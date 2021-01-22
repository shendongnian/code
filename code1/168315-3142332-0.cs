    void BackupDatabase() {
        using(var con = new SqlConnection("...")) {
            con.FireInfoMessageEventOnUserErrors = true;
            con.InfoMessage += con_InfoMessage;
            using(var cmd = new SqlCommand(string.Format(
                "backup database {0} to disk = {1} with description = {2}, name = {3}, stats = 1",
                databaseName,
                backupFilename,
                backupDescription,
                backupName), con)) {
                cmd.ExecuteNonQuery();
            }
            con.InfoMessage -= con_InfoMessage;
            con.FireInfoMessageEventOnUserErrors = false;
        }
    }
    void con_InfoMessage(object sender, SqlInfoMessageEventArgs e) {
        foreach(SqlError info in e.Errors) {
            if(info.Class > 10) {
                // TODO: treat this as a genuine error
            } else {
                // TODO: treat this as a progress message
            }
        }
    }
