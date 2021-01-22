    using (var adapter = new SqlDataAdapter("SELECT * FROM MyTable", connection))
                        {
                            using (var builder = new SqlCommandBuilder(adapter))
                            {
                                adapter.Fill(dataset, "MyTable");
                                adapter.InsertCommand = builder.GetInsertCommand();
                                adapter.Update(dataset, "MyTable");
                            }
                        }
