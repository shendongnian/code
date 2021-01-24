                //replace server namd and instance with name in login window for SQL Server Management Studio (ssms)
                //replace database name wit you database
                string connectionString = "Server=myServerName\myInstanceName;Database=myDataBase;Trusted_Connection=True;";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                for (int i = 0; i < 100; i++)
                {
                    string query = string.Format("INSERT INTO [dbo].[#TEST1] (TEST_ID) VALUES ({0})", i);
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
