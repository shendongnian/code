    bool trigger = true;
    SqlCommand cmdt = con.CreateCommand();
    cmdt.CommandType = CommandType.Text;
    var result = cmdt.ExecuteScalar();       
    bool.TryParse(result, out trigger);
    if (trigger == false) {
        // insert your data. For example:
       string query = "INSERT INTO dbo.FooTable (id,username) VALUES (@id,@username)"; 
       SqlCommand command = new SqlCommand(query, db.Connection);
       command.Parameters.Add("@id","fooID");
       command.Parameters.Add("@username","fooUsername");      
       command.ExecuteNonQuery();
    }
