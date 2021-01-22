    string sql = "SELECT * 
                  FROM Products 
                  WHERE ID = @MyID
                  AND Name LIKE @MyName";
    using (SqlCommand command = new SqlCommand(sql, cn))
    {
        command.Parameters.AddWithValue("@MyID", MyID.Text);
        command.Parameters.AddWithValue("@MyName", "%" + MyName.Text + "%");
        // Etc.
    }
