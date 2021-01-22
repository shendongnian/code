      public DataView GridData
      {
         get
         {
            DataSet ds = new DataSet("MyDataSet");
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
               SqlCommand cmd = conn.CreateCommand();
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT * FROM HumanResources.Employee";
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               da.Fill(ds);
            }
            return ds.Tables[0].DefaultView;
         }
      }
