     SqlDataReader dr;
    
            var ConnecRepository = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
               using (var connection = new SqlConnection(ConnecRepository))
               {
                   connection.Open();
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = connection;
                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText = query;
                   dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
              if (dr.Read()){
                     \\your logic here}
            } 
