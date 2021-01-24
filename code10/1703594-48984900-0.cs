    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    using System.Data;
    
    
    namespace ConsoleApp4
    {
        class Program
        {
            public static string query = null;
            string db1 = "Server=localhost;user id=root;password=;database1=crudasp;";
            string db2 = "Server=localhost;user id=root;password=;database2=crudasp;";
            string db3 = "Server=localhost;user id=root;password=;database3=crudasp;";
            string db4=  "Server=localhost;user id=root;password=;database4=crudasp;";
            string db5 = "Server=localhost;user id=root;password=;database5=crudasp;";
    
            public class DbConnection
            {
                public MySqlConnection MyConn = new MySqlConnection(query);
                public MySqlCommand MyCommand;
                public MySqlDataReader MyReader;
                public MySqlDataAdapter MyAdapter;
            }
    
            DbConnection dbConn = new DbConnection();
    
            void Main(string[] args)
            {
                Console.Write("input your query");
                string queryinput = Console.ReadLine();
                loop(queryinput);
    
            }
    
            public void loop( string queryinputx)
            {
                query = null;
                int x = 0;
                if (x == 1)
                    query = db1;
                else if (x == 2)
                    query = db2;
                else if (x == 3)
                    query = db3;
                else if (x == 4)
                    query = db4;
                else if (x == 5)
                    query = db5;
    
                while (x < 5)
                {
                    try
                    {
                        string SQL =  queryinputx;
                        dbConn.MyConn.Open();
                        dbConn.MyCommand = new MySqlCommand(SQL, dbConn.MyConn);
                    }
                    catch (Exception)
                    {
                        dbConn.MyConn.Close();
                    }
                    x++;
                }
               
            }
        }
    }
