    public class Query
    {
        public void Select(string query)
        {
            DBConnect QConnect = new DBConnect();
            // Here I want to call this class somewhere and pass
            // query string to it and return result from select stmt
            using (MySqlConnection conn = QConnect.Initialize())
            {
                MySqlCommand command = new MySqlCommand(conn,query);
            }
        }
    }
