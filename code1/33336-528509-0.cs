            using(SqlConnection conn = new SqlConnection(CONN_STRING))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT @@DBTS";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                byte[] ts = (byte[]) cmd.ExecuteScalar();
                foreach (byte b in ts)
                {
                    Console.Write(b.ToString("X2"));
                }
                Console.WriteLine();
            }
