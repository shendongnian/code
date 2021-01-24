    using System    ;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    
    
    namespace test
    {
        
        class DBConnect: IDisposable 
        {
            private static String server = "localhost";
            private static String port = "3306";
            private static String database = "testDB";
            private static String username = "root";
            private static String password = "";
    
            private static String connectionString = "Server=" + server + ";Port=" + port + ";Database=" + database + ";Uid=" + username + ";Password=" + password + ";";
             public MySqlConnection con = new MySqlConnection(connectionString);
           
            
    
            public DBConnect() //Constructor
            {
                
                try
                {
                    con.Open();
                    Console.WriteLine("Database connected");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Database Connection Failed");
                    throw new Exception();
                }
    
    
            }
    
    
            public void Dispose()
            {
                con.Close();
            }
        }
    }
