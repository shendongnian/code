    // proper spacing and indentations makes the code easier to read thus more maintainable.
    // Also, Always specify the columns list in an insert statement.
    var tsql = @"INSERT INTO CAMADA (id, team, shift, starttime, jobdate, pm) 
                 VALUES (@id, @team, @shift, @starttime, @jobdate, @pm)";
    // use the using statement to ensure the SqlConnection is closed and disposed when done.
    // This is important not only because it's an IDispsable, but also because that 
    // if you don't dispose it, the connection will not return to the connection pool
    using(var cn = new SqlConnection("**CONNECTION STRING IS WORKING FINE, CHECKED**"))
    {
        // SqlCommand is also an IDisposable
        using(var cmd = new SqlCommand(tsql,cn))
        {
            // CommandType.Text is the default, no need to set it explicitly
            // Use parameters to avoid all kinds of nasty stuff like SQL injection,
            // but also having to handle DateTime string literals formats 
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@team", SqlDbType.Int).Value = team;
            cmd.Parameters.Add("@shift", SqlDbType.Int).Value = shift;
            cmd.Parameters.Add("@starttime", SqlDbType.DateTime).Value = starttime;
            cmd.Parameters.Add("@jobdate", SqlDbType.DateTime).Value = jobdate;
            // Of course, the size is also a guess...
            cmd.Parameters.Add("@pm", SqlDbType.VarChar, 2).Value = pm;
            cn.Open();
            cmd.ExecuteNonQuery();    
        }
    }
