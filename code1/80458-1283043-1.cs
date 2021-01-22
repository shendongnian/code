    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class Program
    {
        static void Main()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=server;database=mydb; Integrated Security=SSPI"))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryID, CategoryName FROM dbo.Categories;";
    
                try
                {
                    connection.Open();
    
                    SqlDataReader reader = command.ExecuteReader();
    
                    // process each row one at a time
                    while (reader.Read())
                    {
                        // reader contains the row (reader[0] is first column, etc)
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
