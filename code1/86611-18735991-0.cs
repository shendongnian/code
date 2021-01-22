    using (var sqlCon = new SqlConnection("Server=127.0.0.1;Database=MyDb;User Id=Me;Password=glop;"))
          {
            sqlCon.Open();
    
            var com = sqlCon.CreateCommand();
            com.CommandText = "select * from BigTable";
            using (var reader = com.ExecuteReader())
            {
    			//here you retrieve what you need
            }
            
    		com.CommandText = "select @@ROWCOUNT";
            var totalRow = com.ExecuteScalar();
    
            sqlCon.Close();
          }
