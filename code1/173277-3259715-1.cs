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
                    //use the '$' notation after the sheet name to indicate that this is
                    // an existing sheet and not to actually create it.  This basically defines
                    // the metadata for the insert statements that will follow.
                    // If the '$' notation is removed, then a new sheet is created named 'Sheet1'.
                    command.CommandText = "CREATE TABLE [Sheet1$] (F1 number, F2 char(255), F3 char(128))";
                    command.ExecuteNonQuery();
                    //now we insert the values into the existing sheet...no new sheet is added.
                    command.CommandText = "INSERT INTO [Sheet1$] (F1, F2, F3) VALUES(4,\"Tampa\",\"Florida\")";
                    command.ExecuteNonQuery();
                    //insert another row into the sheet...
                    command.CommandText = "INSERT INTO [Sheet1$] (F1, F2, F3) VALUES(5,\"Pittsburgh\",\"Pennsylvania\")";
                    command.ExecuteNonQuery();
                }
            }
        }
