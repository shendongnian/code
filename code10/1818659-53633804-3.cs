    bool trigger = true;
    SqlCommand cmdt = con.CreateCommand();
    cmdt.CommandType = CommandType.Text;
    var result = cmdt.ExecuteScalar();       
    bool.TryParse(result, out trigger);
    if (trigger == false) {
        // insert your data. For example:
       string query = "INSERT INTO dbo.FooTable (id,username) VALUES (@id,@username)"; 
       SqlCommand command = new SqlCommand(query, db.Connection);
       string preventNull = null;
       preventNull = preventNull == null ? "Is not null" : "Hey!";
       string fooUserName = null;
       fooUserName = fooUserName == null ? "Bob not null" : "Hey!";
       command.Parameters.Add("@id", preventNull );
       command.Parameters.Add("@username", fooUserName );      
       command.ExecuteNonQuery();
    }
