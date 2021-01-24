    public class DataProvider
    {
        private static string m_connectionString;
        
        public static void SetConnectionString()
        {
            //Or you can use your conventional way to get connection string, but as you can see this call will be one time only, It will help you.
            m_connectionString = ConfigurationSettings.AppSettings["connString"]; 
        }
        
        public static DataTable GetDataFromDataBase(string query)
        {
            DataTable tbl = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(m_connectionString))
            {
                 MySqlCommand cmd = new MySqlCommand(query, conn);
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(tbl);
            }
            return tbl;
        }
    }
