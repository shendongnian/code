     public static void CloseConnection()
        {
            _connection.Close();
            _connection.Dispose();
        }
