         public const string sqlDataConnectionDetails = "Data Source=YOUR-SERVER;Initial Catalog=YourDatabaseName;Persist Security Info=True;User ID=YourUserName;Password=YourPassword";
         public static void ChangeDatabaseSize(int databaseSize) {
            const string preparedCommand = @"
                            ALTER DATABASE Accounting
                            MODIFY FILE
                            (NAME = 'Accounting', SIZE = @size)
                            ";
            using (var varConnection = SqlConnectOneTime(sqlDataConnectionDetails))
            using (SqlCommand sqlWrite = new SqlCommand(preparedCommand, varConnection)) {
                sqlWrite.Parameters.AddWithValue("@size", databaseSize);
                sqlWrite.ExecuteNonQuery();
            }
        }
