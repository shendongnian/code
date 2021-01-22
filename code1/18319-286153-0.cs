    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Book1.xls;Extended Properties=""Excel 8.0;HDR=YES;""";
    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionString)) {
        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT top 13 City,State FROM [Cities$]";
    
        conn.Open();
        System.Data.IDataReader dr = cmd.ExecuteReader();
    
        int row = 2;
        while (dr.Read()) {
            if (row++ >= 4) {
                // do stuff
                Console.WriteLine("{0}, {1}", dr[0], dr[1]);
            }
        }
    }
