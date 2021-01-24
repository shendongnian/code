    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlCommand mysqlCmd = new MySqlCommand("MemberEditORAdd",mysqlCon);
                    mysqlCmd.CommandType = CommandType.StoredProcedure;
                    mysqlCmd.Parameters.AddWithValue("IDFID", IDFID);
                    mysqlCmd.Parameters.AddWithValue("MEMBRNAME", MemberName.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MEMBRRANK", MemberRank.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MEMBRWARN", MemberWarn.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MJOINDATE", MemberJoinDate.Text.Trim());
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Operation Done!");
                }
