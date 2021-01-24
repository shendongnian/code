    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class Program
    {
    
        static void Main(string[] args)
        {
    
            SqlDependency.Start(Utility.getConnectionString());
    
            GetDataWithSqlDependency();
            Console.WriteLine("Waiting for data changes");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
    
            SqlDependency.Stop(Utility.getConnectionString());
    
        }
    
        static void GetDataWithSqlDependency()
        {
    
            using (var connection = new SqlConnection(Utility.getConnectionString()))
            using (var cmd = new SqlCommand(@"SELECT [Services].[ServiceName], [Services].[ServicePrice] from dbo.Services;", connection))
            {
                var dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
                connection.Open();
                cmd.ExecuteReader().Dispose();
            }
    
        }
        static void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
    
            Console.WriteLine($"OnDependencyChange Event fired. SqlNotificationEventArgs: Info={e.Info}, Source={e.Source}, Type={e.Type}");
    
            if ((e.Info != SqlNotificationInfo.Invalid)
                && (e.Type != SqlNotificationType.Subscribe))
            {
                SqlDependency.Start(Utility.getConnectionString());
                GetDataWithSqlDependency();
                Console.WriteLine($"Data changed.");
            }
            else
            {
                Console.WriteLine("SqlDependency not restarted");
            }
    
        }
    
    }
    
    static class Utility
    {
        public static string getConnectionString()
        {
            return @"Data Source=.;Initial Catalog=YourDatabase;Application Name=SqlDependencyExample;Integrated Security=SSPI";
        }
    
    }
