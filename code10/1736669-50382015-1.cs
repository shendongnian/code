    public class Authenticateuser
    {
        public MySqlConnection connection = new MySqlConnection(connstring);
      
        private static string connstring = ConfigurationManager
            .ConnectionStrings["dbPCTECH"].ConnectionString;
        private int Userid = 0;
        
        public Open() => connection.Open();
    }
