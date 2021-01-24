        string s = @"Server=(local)\SQLEXPRESS;Database=Test;Integrated Security=SSPI;";
        using(SqlConnection cn = new SqlConnection(s))
        {
            string queryString = "SELECT * from tbclienti";
            try
            {    
              cn.Open();
              // Create the Command and Parameter objects.
              SqlCommand command = new SqlCommand(queryString, cn);
              SqlDataReader reader = command.ExecuteReader();
              while (reader.Read())
              {
                 Text = reader[0].ToString();
                 label1.Text = reader[1].ToString()+ " " + reader[2].ToString();
               }
               reader.Close();
             }
             catch(Exception ex) 
             {
                 // see if error appear
             }
             finally
             {
               cn.Close();
             }
        }
