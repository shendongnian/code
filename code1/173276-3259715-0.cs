        //Most of this code was from David Hayden's blog:
        // http://www.davidhayden.com/blog/dave/archive/2006/05/26/2973.aspx
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\TestSO1.xls;Extended Properties=""Excel 8.0;HDR=NO;""";
            DbProviderFactory factory =
              DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand command = connection.CreateCommand())
                {
                    connection.Open();  //open the connection
                    command.CommandText = "CREATE TABLE Sheet1 (F1 number, F2 char(255), F3 char(128))";
                    command.ExecuteNonQuery();  //create the sheet before doing any inserts
                    command.CommandText = "INSERT INTO [Sheet1$] (F1, F2, F3) VALUES(4,\"Tampa\",\"Florida\")";
                    command.ExecuteNonQuery();  //now insert a row into the sheet
                }
            }
        }
