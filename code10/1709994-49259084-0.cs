    private List<short> SQLColumnsToList()
        {
            using (var conn = new SqlConnection(/*Your connection string here*/))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from db2prod.questions where key_id = @keyID";
                cmd.Parameters.AddWithValue("keyID", /*Your ID here*/);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var list = new List<short>();
                        for (int i = 0; i < rdr.FieldCount; ++i)
                            list.Add(rdr.GetInt16(i));
                        return list;
                    }
                    throw new Exception("No row found");
                }
            }
        }
