    SqlDataAdapter sqlDa = new SqlDataAdapter($"SELECT @what FROM {ConfigurationManager.AppSettings["SQLTableName"]} WHERE @col = @which", sqlCon);
    
    sqlDa.SelectCommand.Parameters.AddWithValue("@what", ConfigurationManager.AppSettings["SQLFirst3FieldResults"]);
    sqlDa.SelectCommand.Parameters.AddWithValue("@col", ConfigurationManager.AppSettings["SQLSearchColumn"]);
    sqlDa.SelectCommand.Parameters.AddWithValue("@which", SearchBox.Text.ToString());
    
    DataTable dtbl = new DataTable();
    sqlDa.Fill(dtbl);
