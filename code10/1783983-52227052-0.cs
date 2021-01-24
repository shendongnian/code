    static void Update(int id, string headword)
    {
       try
       {	
       //You should create connectionString with correct details otherwise fail connection
        string connectionString =
            "server=.;" +
            "initial catalog=employee;" +
            "user id=sa;" +
            "password=123";
        using (SqlConnection conn =
            new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd =
                new SqlCommand("UPDATE headwords SET Headword=@headword" +
                    " WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@headword", headword);
               
                int rows = cmd.ExecuteNonQuery();
                
            }
        }
       }
    catch (SqlException ex)
    {
        //Handle sql Exception
    }
}
