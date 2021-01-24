    using(MySqlConnection Connection = new MySqlConnection("SERVER=localhost;UID=root;"))
    using(MySqlCommand Command = new MySqlCommand("ALTER USER 'username'@'localhost' IDENTIFIED BY 'password';", Connection))
    {
        Connection.Open();
        Command.ExecuteNonQuery();
    }
