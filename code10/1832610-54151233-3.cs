    SqlDataAdapter sqlDa = new SqlDataAdapter($"SELECT @what FROM {ConfigurationManager.AppSettings["SQLTableName"]} WHERE {ConfigurationManager.AppSettings["SQLSearchColumn"]} = @which", sqlCon);
    
    sqlDa.SelectCommand.Parameters.AddWithValue("@what", ConfigurationManager.AppSettings["SQLFirst3FieldResults"]);
    sqlDa.SelectCommand.Parameters.AddWithValue("@which", SearchBox.Text.ToString());
    
    DataTable dtbl = new DataTable();
    sqlDa.Fill(dtbl);
