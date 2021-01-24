            private static int CreateTableAndIndexes(SqlServerCacheOptions options)
        {
            using (var connection = new SqlConnection(options.ConnectionString))
            {
                connection.Open();
                var sqlQueries = new SqlQueries(options.SchemaName, options.TableName);
                var command = new SqlCommand(sqlQueries.TableInfo, connection);
                using (var reader = command.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        return 1;
                    }
                }
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command = new SqlCommand(sqlQueries.CreateTable, connection, transaction);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(
                            sqlQueries.CreateNonClusteredIndexOnExpirationTime,
                            connection,
                            transaction);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 1;
                    }
                }
            }
            return 0;
        }
