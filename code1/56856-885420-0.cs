    private static void GetObjects()
    {
        List<MyObject> objects = new List<MyObject>();
        string sql = "Select ...";
        using (SqlConnection connection = GetConnection())
        {
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);)
            {
                while (reader.Read())
                    objects.Add(_ReadRow(reader));
            }
        }
    }
    
    private static MyObject _ReadRow(SqlDataReader reader)
    {
        MyObject o = new MyObject();
        o.field0 = reader.GetString(0);
        o.field1 = reader.GetString(1);
        o.field2 = reader.GetString(2);
        // Do other manipulation to object before returning
        return o;
    }
    class MyObject{}
