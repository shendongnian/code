    public Auto RendszamAlapjan (string rendszam)
          {
             Auto auto = null;
    
             using (OleDbConnection connection = new OleDbConnection(KapcsolatAdatai.KapcsolatiString))
             {
                OleDbCommand command = connection.CreateCommand();
    
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AtoRendszamAlapjan";
                command.Parameters.Add("@RendszamParam", OleDbType.VarChar).Value = rendszam;
    
                connection.Open();
    
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                   while (reader.Read())
                   {
                      auto = MapEntiy(reader);
                   }
                }
             }
    
             return auto;
          }
