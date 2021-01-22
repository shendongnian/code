    const string connString = "Data Source=localhost;Initial Catalog=OnlineQuiz;Integrated Security=True";
    
    static void Main(string[] args)
    {
    	string query = string.Format("SELECT * FROM [User] WHERE name like @name");
    
    	using (SqlConnection conn = new SqlConnection(connString))
    	{
    		using (SqlCommand cmd = new SqlCommand(query, conn))
    		{
    			cmd.Parameters.AddWithValue("@name", "F%");
    
    			conn.Open();
    			using (SqlDataReader reader = cmd.ExecuteReader())
    			{
    						
    				while (reader.Read())
    				{
    					Console.WriteLine(reader.GetValue(1));
    				}
    			}
    		}
    	}
    }
