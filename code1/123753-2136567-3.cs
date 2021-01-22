    class Program
    {
        static void Main(string[] args)
        {
            string strCount;
            SqlConnection Conn = new SqlConnection
               ("Data Source=ServerName;integrated " +
               "Security=sspi;initial catalog=TestingDB;");
            SqlCommand testCMD = new SqlCommand
               ("sp_spaceused", Conn);
            testCMD.CommandType = CommandType.StoredProcedure;        
            Conn.Open();
            SqlDataReader reader = testCMD.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   Console.WriteLine("Name: " + reader["database_name"]); 
                   Console.WriteLine("Size: " + reader["database_size"]); 
                }
            }
  
            Console.ReadLine();
        }
    }
