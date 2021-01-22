    string conn_str = ConfigurationManager.ConnectionStrings["MySQLServer"].ConnectionString;
   
    DataTable All_Table = new DataTable();
    using (MySqlConnection cn = new MySqlconnection(conn_str))
    using (MySqlCommand cmd = new MySqlCommand(m_SQL, cn))
    {
        try
        {
            cn.Open();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                All_Table.Load(rdr);
                rdr.Close();
            }
         }
         catch (Exception ex)
        {
            string s = ex.Message;
        }
    }
