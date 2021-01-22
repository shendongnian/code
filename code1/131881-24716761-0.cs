    using System.Data.SqlClient;
    
            private void button1_Click(object sender, EventArgs e)
        {
    
            OdbcConnection conn = new OdbcConnection();
            conn.ConnectionString =
            "Driver={SQL Server};" +
            "Server=NomeServidor;" +
            "DataBase=NomeBD;" +
            "Uid=;" +
            "Pwd=;";
            conn.Open();
    
            OdbcCommand DbCommand = conn.CreateCommand();
            DbCommand.CommandText = "SELECT * FROM NomeTabela";
            OdbcDataReader DbReader = DbCommand.ExecuteReader();
    
            for (int ordinal = 0; ordinal < DbReader.FieldCount; ordinal++)
                Console.WriteLine("Field {0}: {1}", ordinal, DbReader.GetName(ordinal));
        }
