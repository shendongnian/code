    app.Run(async context =>
            {
                if( context.Request.Url  == "") // Match with something
                {
                Console.Write("got here");
                String course = "CS3705";
                int user = 8;
    
                SqlConnection con = new SqlConnection("host;initial catalog = timeslice;user id=timeslice;password=********");
                string query = "Insert into COURSES (courseName, userId) Values ('" + course + "', '" + user + "')";
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandType = CommandType.Text;
                comm.CommandText = query;
    
                con.Open();
                comm.ExecuteNonQuery();
                }
                await context.Response.WriteAsync("Hello");
            });
