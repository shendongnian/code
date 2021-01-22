    using System.Data.SQLite;  // need to install sqlite .net driver
    String path_to_db = @"C:\Documents and Settings\Jeff\Application Data\Mozilla\Firefox\Profiles\yhwx4xco.default\places.sqlite";
    String path_to_temp = System.IO.Path.GetTempFileName();
    System.IO.File.Copy(path_to_db, path_to_temp, true);
    SQLiteConnection sqlite_connection = new SQLiteConnection("Data Source=" + path_to_temp + ";Version=3;Compress=True;Read Only=True;");
    SQLiteCommand sqlite_command = sqlite_connection.CreateCommand();
    sqlite_connection.Open();
    sqlite_command.CommandText = "SELECT moz_bookmarks.title,moz_places.url FROM moz_bookmarks LEFT JOIN moz_places WHERE moz_bookmarks.fk = moz_places.id AND moz_bookmarks.title != 'null' AND moz_places.url LIKE '%http%';";
    SQLiteDataReader sqlite_datareader = sqlite_command.ExecuteReader();
    while (sqlite_datareader.Read())
        {
            System.Console.WriteLine(sqlite_datareader[1]);
        }
    sqlite_connection.Close();
    System.IO.File.Delete(path_to_temp);
