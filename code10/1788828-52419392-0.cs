    string connstr = "server=localhost;user=root;pwd=mypass;database=mydb;sslmode=none;convertdatetime=true;";
    string backupfile = "C:\\backup.sql";
    
    using (MySqlConnection conn = new MySqlConnection(connstr))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                conn.Open();
                cmd.Connection = conn;
    
                mb.ExportToFile(backupfile);
    
                conn.Close();
            }
        }
    }
