        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = your_query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.Parameters.Add(new SqlParameter("@idCar", idCar));
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //reader here
            }
        }
