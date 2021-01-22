    using (StreamWriter sw = new StreamWriter("output.txt"))
    {
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = script;
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        sw.WriteLine(rdr.Item("colName").ToString();
                    }
                }
            }
        }
    }
