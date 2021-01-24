    using System;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static   void Main(string[] args)
            {
                SqlConnection connection = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;;Connection Timeout=0");
                connection.Open();
                var SPID = GetSPID(connection);
                var task1 = new Task(() => doLongSql(connection),
                   TaskCreationOptions.LongRunning);
                task1.Start();
    
             
    
                Thread.Sleep(1000 * 10);//wait 10 seconds
    
                if (!task1.IsCompleted)
                {
                    
                   KillSPID( SPID);
                    
                }
    
                Task.WaitAll(task1);
    
            }
            static int GetSPID(SqlConnection connection)
            {
                SqlCommand command = new SqlCommand("Select @@SPID ",connection);
                int SPID = Convert.ToInt32( command.ExecuteScalar()) ;
                return SPID;
            }
    
            static void KillSPID( int SPID)
            {
                SqlConnection connection = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;");
                connection.Open();
                SqlCommand command = new SqlCommand($"KILL {SPID}", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
     
            static void doLongSql(SqlConnection connection)
            {
       
                using (connection)
                {
                    SqlCommand command = new SqlCommand(
                      "WAITFOR DELAY '01:00'", //wait 1 minute
                      connection);
                     command.ExecuteNonQuery();
                  }
            }
    
    
        }
    }
