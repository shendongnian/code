    using System;
    using System.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    namespace MyTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var database = DatabaseFactory.CreateDatabase();
                var command = database.GetStoredProcCommand("SomeSP");
                using (IDataReader reader = database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("X: {0} Y: {1} Z: {2}", 
                                        reader["SomeField"], 
                                        reader["AnothterField"], 
                                        reader["Enabled"]);
                    }
                }
                Console.ReadLine();
            }
        }
    }
