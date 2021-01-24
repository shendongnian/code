    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    namespace TestingColumnIDPullling
    {
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con;
            SqlDataReader reader;
            try
            {
                int id;
                con = new SqlConnection(Properties.Settings.Default.Setting);
                con.Open();
                Console.WriteLine("Enter User Id");
                id = Convert.ToInt32(Console.ReadLine());
                string query = "select ordinal_position from information_schema.columns c where table_name = 'Test' and table_schema = 'dbo' and column_name = 'Password'";
                reader = new SqlCommand(query, con).ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}", reader.GetInt32(0));
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        }
    }
