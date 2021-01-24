    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Executing query...");
            string customerID = "ID_HERE";
            using (SqlConnection connection = new SqlConnection("CONNECTION_STRING"))
            {
                connection.Open();
    
                using (SqlCommand command = new SqlCommand(
                    "SELECT col0, col1, col2, col3, col4, col5, col6, col7, col8, col9 FROM Table_name WHERE col1 LIKE @ID", connection))
                {
    
                    command.Parameters.Add(new SqlParameter("ID", customerID));
                    var sw = new Stopwatch();
    
                    sw.Start();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int col0 = reader.GetInt32(0);
                        int col1 = reader.GetInt32(1);
                        string col2 = reader.GetString(2);
                        string col3 = reader.GetString(3);
                        int col4 = reader.GetInt32(4);
                        int col5 = reader.GetInt32(5);
                        short col6 = reader.GetInt16(6);
                        string col7 = reader.GetString(7);
                        string col8 = reader.GetString(8);
                        int col9 = reader.GetInt32(9);
                        Console.WriteLine("col0 = {0}, col1 = {1}, col2 = {2}, col3 = {3}, col4 = {4}, col5 = {5}, col6 = {6}, col7 = {7}, col8 = {8}, col9 = {9}",
                            col0,
                            col1,
                            col2,
                            col3,
                            col4,
                            col5,
                            col6,
                            col7,
                            col8,
                            col9
                            );
                    }
                    var elapsed = sw.Elapsed;
    
                    Console.WriteLine($"Query Executed and Results Returned in {elapsed.Seconds}sec");
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    
    }
