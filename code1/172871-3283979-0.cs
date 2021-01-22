            static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\SOTest2.xls;Extended Properties=""Excel 8.0;HDR=NO;""";
            DbProviderFactory factory =
              DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();  //open the connection 
                    command.CommandText = "CREATE TABLE [Sheet1] (F1 number);";
                    command.ExecuteNonQuery();  //create the sheet before doing any inserts 
                    command.CommandText = "INSERT INTO [Sheet1$] (F1) VALUES(4)";
                    command.ExecuteNonQuery();  //now insert a row into the sheet 
                }
            }
        }
