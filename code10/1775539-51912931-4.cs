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
    
    conn.Open();
    cmd.ExecuteNonQuery();
    }
