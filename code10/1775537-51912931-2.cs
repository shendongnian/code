    using (SqlConnection conn = new SqlConnection("Server =Hassan; Database =FBT; Integrated Security =SSPI;"))
    using (SqlCommand cmd = new SqlCommand("StoredProcedure", conn))
    {    
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
        //you should know whats the type of your primary key i assumed its int
        adapt.SelectCommand.Parameters.Add(new SqlParameter("@PrimaryKey", SqlDbType.Int)); 
        adapt.SelectCommand.Parameters["@PrimaryKey"].Value = PrimaryKey;
        //lets assume you are updating a Name which is string then
        adapt.SelectCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
        adapt.SelectCommand.Parameters["@Name"].Value = Name;
    
        // and again to fill the data table - no need to explicitly call `conn.Open()` - 
        // the SqlDataAdapter automatically does this (and closes the connection, too)
        DataTable dt = new DataTable();
        adapt.Fill(dt);
    
        if (dt.Rows.Count > 0)
        {
           MessageBox.Show("Connection Succedded");
        }
        else
        {
           MessageBox.Show("Connection Fails");
        }
    }
