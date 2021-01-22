            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""" + scratchFile 
                + @""";Extended Properties=""Excel 12.0 xml;HDR=YES""";   
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = @"CREATE TABLE [RawData$] " + 
                        "([Organization] varchar(255), " +
                        "[Department] varchar(255), [TotalSales] int, [TotalHours] int)";
                    command.ExecuteNonQuery();
                    
                    command.CommandText = @"INSERT INTO [RawData$] " +
                        "(Organization,Department,TotalSales,TotalHours)" +
                        "VALUES('Organization','Department',700,70)";
                    command.ExecuteNonQuery();
                    
                }
            }
