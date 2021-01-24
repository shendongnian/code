    SqlDataAdapter sqlDa = new SqlDataAdapter(string.Format(
                    "SELECT {0} FROM {1} WHERE {2} = '" + SearchBox.Text.ToString() + "'", 
                     ConfigurationManager.AppSettings["SQLFirst3FieldResults"],
                     ConfigurationManager.AppSettings["SQLTableName"],
                     ConfigurationManager.AppSettings["SQLSearchColumn"]), sqlCon);
    
                DataTable dtbl = new DataTable();
    
                sqlDa.Fill(dtbl);
