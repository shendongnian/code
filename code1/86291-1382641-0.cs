    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.IO;
    
    // Program.cs
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                MailArchiver.Run();
                Console.WriteLine("Application completed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred:");
                Console.WriteLine(ex.ToString());
            }
    
        }
    }
    // Reads new messages from DB, save it to a report file 
    // and then clears the table
    public static class MailArchiver
    {
    
        public static void Run()
        {
            // Might be a good idea to a datetime suffix 
            ReportWriter.WriteFile(@"c:\INMS.txt");
            CopyAndClearMessages();
        }
    
        private static void CopyAndClearMessages()
        {
            SqlConnection cn = DbConnectionFactory.CreateConnection();
            cn.Open();
    
            try
            {
                SqlTransaction tx = cn.BeginTransaction();
    
                try
                {
                    CopyMessages(cn, tx);
                    DeleteMessages(cn, tx);
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
            finally
            {
                cn.Close();
            }
        }
    
        private static void DeleteMessages(SqlConnection cn, SqlTransaction tx)
        {
            var sql = "DELETE FROM tblOutbox";
            var cmd = new SqlCommand(sql, cn, tx);
            cmd.CommandTimeout = 60 * 2;  // timeout 2 minutes 
            cmd.ExecuteNonQuery();
        }
    
        private static void CopyMessages(SqlConnection cn, SqlTransaction tx)
        {
            var sql = "INSERT INTO tblSend (ip, msg, date) SELECT ip, msg, date FROM tblOutbox";
            var cmd = new SqlCommand(sql, cn, tx);
            cmd.CommandTimeout = 60 * 2;  // timeout 2 minutes 
            cmd.ExecuteNonQuery();
        }
    }
    
    // Provides database connections to the rest of the app.
    public static class DbConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            // Retrieve connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["MailDatabase"].ConnectionString;
            var cn = new SqlConnection(connectionString);
    
            return cn;
        }
    }
    
    // Writes all the data in tblOutbox to a CSV file
    public static class ReportWriter
    {
        private static SqlDataReader GetData()
        {
            SqlConnection cn = DbConnectionFactory.CreateConnection();
            cn.Open();
    
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM tblOutbox";
                cmd.Connection = cn;
    
                return cmd.ExecuteReader();
            }
            finally
            {
                cn.Close();
            }
        }
    
        public static void WriteFile(string filename)
        {
            if (File.Exists(filename))
            {
                // This might be serious, we may overwrite data from the previous run.
                // 1. You might want to throw your own custom exception here, should want to handle this
                //    condition higher up.
                // 2. The logic added here is not the best and added for demonstration purposes only.
                throw new Exception(String.Format("The file [{0}] already exists, move the file and try again"));
            }
            var tw = new StreamWriter(filename);
    
            try
            {
                // Adds header record that describes the file contents
                tw.WriteLine("id,ip address,message,datetime");
    
                using (SqlDataReader reader = GetData())
                {
                    while (reader.Read())
                    {
                        var id = reader["id"].ToString();
                        var ip = reader["ip"].ToString();
    
                        //msg might contain commas, surround value with double quotes
                        var msg = reader["msg"].ToString();
                        var date = reader["data"].ToString();
    
                        if (IfValidRecord(id, ip, msg, msg, date))
                        {
                            tw.WriteLine(string.Format("{0},{1},{2},{3}", id, ip, msg, date));
                        }
                    }
    
                    tw.WriteLine("Report generated at : " + DateTime.Now);
                    tw.WriteLine("--------------------------------------");
                }
    
            }
            finally
            {
                tw.Close();
            }
    
        }
    
        private static bool IfValidRecord(string id, string ip, string msg, string msg_4, string date)
        {
            // this answers your question on how to handle validation per record.
            // Add required logic here
            return true;
        }
    }
