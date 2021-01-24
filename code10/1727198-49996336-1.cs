                using (var connection =
                    new SqlConnection(
                        "@"Data Source=******;Initial Catalog=UserDB;Integrated Security=True""))
                {
                    connection.Open();
                    using (var command =
                            new SqlCommand(
                                @"
    insert into UserTabelle([Name], [Other])
    values (@name, @other)",
                                connection)){
                        command.Parameters.AddWithValue("@name", txtBenutzerName.Text);
                        command.Parameters.AddWithValue("@other", "some value");
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
