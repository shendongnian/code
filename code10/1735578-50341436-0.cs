    public List<DateTime> getDates() {
        string connString = "Server=localhost;Database=test;Uid=root;Pwd='';SslMode=none";
        using (var connection = new MySqlConnection(connString)) {
            return connection.Query<DateTime>("SELECT dates FROM abctable").ToList();            
        }
    }
