    Using (SqlConnection conn = new SqlConnection(connstr))
    {
        Using (SqlCommand command = new SqlCommand("INSERT INTO FOO (col) VALUES (@arg)"))
        {
            command.Connection = conn;
            command.Parameters.AddWithValue("@arg",SpecialCharsString);
            command.ExecuteNonQuery();
        }
    }
