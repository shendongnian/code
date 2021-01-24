    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    namespace DatbaseApplication
    {
        public class Database
        {
            private MySqlConnection connection;
            public Database()
            {
                try
                {
                    connection = new MySqlConnection("server=192.168.0.0;user id=databaseuser;password=databasepassword;persistsecurityinfo=True;database=databasename;allowuservariables=True");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
         }
    }
