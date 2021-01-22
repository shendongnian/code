    using System.Data.SQLite; // downloaded from http://sourceforge.net/projects/adodotnetsqlite
    namespace sqlite_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path_to_db = @"C:\places.sqlite"; // copied here to avoid long path
                SQLiteConnection sqlite_connection = new SQLiteConnection("Data Source=" + path_to_db + ";Version=3;New=True;Compress=True;");
    
                SQLiteCommand sqlite_command = sqlite_connection.CreateCommand();
    
                sqlite_connection.Open();
    
                sqlite_command.CommandText = "select * from moz_places";
    
                SQLiteDataReader sqlite_datareader = sqlite_command.ExecuteReader();
    
                while (sqlite_datareader.Read())
                {
                    // Prints out the url field from the table:
                    System.Console.WriteLine(sqlite_datareader["url"]);
                }
            }
        }
    }
