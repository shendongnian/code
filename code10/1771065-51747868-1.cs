      public DataTable Select(string selectStatment, string parameterName = "", byte[] x = null)
        {
            using (var con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            //using (var con = new SqlConnection(@"Data Source=.\MiDonations.db; Version=3;"))
            using (var da = new SQLiteDataAdapter(selectStatment, con))
            using (var dt = new DataTable())
            {
                if (parameterName != "")
                {
                    da.SelectCommand.Parameters.Add(parameterName, DbType.String).Value = x;
                }
                da.Fill(dt);
                return dt;
            }
            
           
        }
