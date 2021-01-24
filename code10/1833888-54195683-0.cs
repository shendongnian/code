    namespace App
    {
        static void Main(string[] args)
        {
             using(var conn = new System.Data.OleDb.OleDbConnection{connString = "..info.."})
            {
                 conn.Open();
                 Console.WriteLine("DS:{0} DB: {1}",conn.DataSource,conn.Database);   
            }
        }
    }
