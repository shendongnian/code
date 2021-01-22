    public IEnumerable<MyDataClass> ReadData()
    {
        using (SqlConnection conn = new SqlConnection("myConnString"))
        using (SqlCommand comm = new SqlCommand("myQuery", conn))
        {
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    yield return new MyDataClass(... data from reader ...);
                }
            }
        }
    }
