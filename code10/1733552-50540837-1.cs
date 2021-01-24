    using System;
    using System.Data;
    using System.Data.SqlClient;
    namespace BackupRestore
    {
        class Program
        {
            static void Main(string[] args)
            {
                BackupDatabase("test", @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Backup\test.bak");
                RestoreDatabase("test", @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\Backup\test.bak");
            }
            private static void RestoreDatabase(string databaseName, string backupPath)
            {
                string commandText = $@"USE [master];
        ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        RESTORE DATABASE [{databaseName}] FROM DISK = N'{backupPath}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5;
        ALTER DATABASE [{databaseName}] SET MULTI_USER;";
                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "master",
                    IntegratedSecurity = true
                };
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            private static void BackupDatabase(string databaseName, string backupPath)
            {
                string commandText = $@"BACKUP DATABASE [{databaseName}] TO DISK = N'{backupPath}' WITH NOFORMAT, INIT, NAME = N'{databaseName}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "master",
                    IntegratedSecurity = true
                };
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
