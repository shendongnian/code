    public DataTable ExecuteReader(string cmdTxt)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
               using(SqlCommand cmd = new SqlCommand(cmdTxt, conn))
               {
                    conn.Open();
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        DataTable dt=new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
               }
            }
        }
