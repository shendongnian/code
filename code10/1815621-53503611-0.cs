    public void OpenConnection()
    {
       connection = new MySqlConnection(strConnection);
       connection.Open();
    }
