    using (SqlConnection icon = new SqlConnection(sqlConnectionString))
    {
        icon.Open();
        using (SqlCommand icmd = new SqlCommand(@"insert into table " +
            "values (@ID, @FNAME, @TW, @YD, @WKEND)", icon))
        {
            icmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Real));
            icmd.Parameters.Add(new SqlParameter("@FNAME", SqlDbType.NVarChar));
            icmd.Parameters.Add(new SqlParameter("@TW", SqlDbType.Real));
            icmd.Parameters.Add(new SqlParameter("@YD", SqlDbType.Real));
            icmd.Parameters.Add(new SqlParameter("@WKEND", SqlDbType.Date));
            using (OleDbConnection con = new OleDbConnection(connstring))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();  // Skip Header Row
                        while (reader.Read())
                        {
                            for (int i = 0; i < 5; i++)
                                icmd.Parameters[i].Value = reader.GetValue(i);
                            icmd.ExecuteNonQuery();
                        }
                        reader.Close();
                    }
                }
            }
        }
    }
