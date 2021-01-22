     using (SqlConnection conn = new SqlConnection(ConnectionString))
      {
         SqlCommand cmd1 = new SqlCommand("spSelectAllTypeA", conn);
                     cmd1.CommandType = CommandType.StoredProcedure;
         SqlCommand cmd2 = new SqlCommand("spSelectAllTypeB", conn);
          
    conn.Open();
    
        setDDL(ref ddlTripTypeA, cmd1, "Type", "pkiTypeAID");
        
        setDDL(ref ddlTripTypeB, cmd2, "Type", "pkiTypeBID");
    }
        ..end of method..
        protected void setDDL( ref DropDownList ddl, SqlCommand cmd, string textField, string valueField)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                ddl.DataSource = reader;
                ddl.DataTextField = textField;
                ddl.DataValueField = valueField;
                ddl.DataBind();
                reader.Close();
            }
