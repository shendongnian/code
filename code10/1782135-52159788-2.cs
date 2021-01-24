    public DataSet Dropdown_Feesgroup()
        {
            var ds1 = new DataSet();
            using (con = new MySqlConnection(ConfigurationManager.ConnectionStrings["schoolmanagment_connectionString"].ToString()))
            {
                try
                {
                    con.Open();
                    cmd = new MySqlCommand("select id,name from fee_groups", con);
                    da = new MySqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds, "fee_groups");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ds1 = ds;
                    }
                }
                catch (Exception ex)
                {
                    var a = ex.ToString();
                    throw;
                }
                finally { con.Close(); }
                return ds;
            }
        }
