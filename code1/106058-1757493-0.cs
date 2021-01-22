    MySql.Data.MySqlClient.MySqlConnection conn;
    string myConnectionString;
    myConnectionString = "server=127.0.0.1;uid=root;pwd=12345;database=test;";
    try
    {
        conn = new MySql.Data.MySqlClient.MySqlConnection();
        conn.ConnectionString = myConnectionString;
        conn.Open();
    }
    catch (MySql.Data.MySqlClient.MySqlException ex)
    {
        MessageBox.Show(ex.Message);
    }
