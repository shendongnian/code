    public bool ImageExists(string filehash)
    {
        bool result = false;
        using (SqlConnection connection = SQLConnection.GetConnection())
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(0) FROM employee_product WHERE ImageHash = @ImageHash", connection))
            {
                connection.Open();
                int imagecount = (int)cmd.ExecuteScalar();
                result = imagecount == 0;
                connection.Close();
            }
        }
        return(result);
    }
  
