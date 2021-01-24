    SqlDataAdapter sqlDa = new SqlDataAdapter($"SELECT {ConfigurationManager.AppSettings["SQLFirst3FieldResults"]} FROM {ConfigurationManager.AppSettings["SQLTableName"]} WHERE {ConfigurationManager.AppSettings["SQLSearchColumn"]} = @which", sqlCon);
    
    sqlDa.SelectCommand.Parameters.AddWithValue("@which", SearchBox.Text.ToString());
    
    DataTable dtbl = new DataTable();
    sqlDa.Fill(dtbl);
