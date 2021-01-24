        using (var con = new SqlConnection(setting.ConnectionString))
        {
            //some codes (edited)
            using (SqlCommand command = new SqlCommand(con))
            {
                command.CommandText = "procedurename1";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", sb.ToString()));
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }
            }
        }
