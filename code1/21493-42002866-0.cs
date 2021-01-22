        internal static Guid InsertNote(Note note)
        {
                Guid id;
                using (
                    var connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString))
                {
                    connection.Open();
                    using (
                        var command =
                            new SqlCommand(
                                "INSERT INTO Notes ([Title],[Text]) " +
                                "OUTPUT inserted.id " +
                                $"VALUES ('{title}','{text}');", connection))
                    {
                        command.CommandType = CommandType.Text;
                        var reader = command.ExecuteReader();
                        reader.Read();
                        id = reader.GetGuid(reader.GetOrdinal("id"));
                    }
                    connection.Close();
                }
                return id;
        }
