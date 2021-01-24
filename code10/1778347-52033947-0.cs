    public static void InitializeDB()
        {
            dbConn = new MySqlConnection(MySQLConnectionString);
            dbConn.Open();
            try
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM S1", dbConn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int a = 0;
                    if (dt.Rows.Count > 0)
                    {
                        string[] UserName = new string[dt.Rows.Count];
                        string[] UserENumber = new string[dt.Rows.Count];
                        string[] UserNumber = new string[dt.Rows.Count];
                        string[] UserNickname = new string[dt.Rows.Count];
                        string[] UserMail = new string[dt.Rows.Count];
                        for (a = 0; a < dt.Rows.Count; a++)
                        {
                            UserName[a] = dt.Rows[a]["Name"].ToString();
                            UserENumber[a] = dt.Rows[a]["Enumber"].ToString();
                            UserNumber[a] = dt.Rows[a]["Number"].ToString();
                            UserNickname[a] = dt.Rows[a]["Nickname"].ToString();
                            UserMail[a] = dt.Rows[a]["Mail"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbConn.Close();
            }
        }
