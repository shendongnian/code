       public string GetSqlConnection()
        {
            return  System.Configuration.ConfigurationManager.AppSettings["SqlConnectionString"];
        }
       public DataSet getDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(GetSqlConnection());
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            conn.Dispose();
            da.Dispose();
            return ds;
        }
