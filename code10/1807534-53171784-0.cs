    void countVR(int kk)
    {
        string selectString = "SELECT COUNT(*) FROM cllohn" + (Jahr % 100).ToString("00") + " WHERE lzVSTR=@KK";
        if (filtsel == selstr)
        {
            using (IDbConnection con = DatabaseFactory.Connect("CL" + (Jahr % 100).ToString("00"), true))
            {
                //con.Open();
                using (IDbCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = selectString;
                    cmd.Parameter.AddWithValue("@KK", kk.ToString());
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            zeilenCount = reader.GetInt32(0);
                            //System.Diagnostics.Debug.WriteLine("Zeilen in " + kk + ": " +zeilenCount);
                        }
                    }
                }
            }
        }
    }
