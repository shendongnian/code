                using (TestEntities entities = new TestEntities())
                {
                    DbConnection connection = entities.Connection;
                    connection.Open();
                    DbCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "TestEntities.CustomerDelete";
                    command.Parameters.Add(new EntityParameter("CustomerId", DbType.Int32) { Value = 1 });
                    command.ExecuteScalar();
                    connection.Close();
                }
