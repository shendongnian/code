    private async void DBConnect() 
    {
       awiat Task.Run(() => 
       MySqlConnection DBConnetion = new MySqlConnection(ConString);
       DBConnection.Open();
    });
