     string connstring ="Server=localhost;Database=testDB;Uid=UserName;Pwd=yourPassword;";
        MySqlConnection connection = new MySqlConnection(connstring);
        connection.Open();
    Console.WriteLine("Connected");
    connection.close();
