    using (var adapter = new SqlDataAdapter("SELECT * FROM MyTable", connection))
                    {
                        using (var builder = new SqlCommandBuilder(adapter))
                        {
                            adapter.Fill(dt);
                            adapter.Update(dt);
                        }
                    }
