    public static DataTable GetSqlTable(string sqlSelect)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(conStr);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
            if (connection.State != ConnectionState.Open)
            {
                return table;
            }
            SqlCommand cmd = new SqlCommand(sqlSelect, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            try
            {
                adapter.Fill(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            connection.Close();
            connection.Dispose();
            return table;
        }
    public static void GetSqlNonQuery(string sqlSelect)
        {
            string newObject = string.Empty;
            string strConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();
            if (connection.State != ConnectionState.Open)
            {
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sqlSelect, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                string x = ex.Message + ex.StackTrace;
                throw;
            }
        }
