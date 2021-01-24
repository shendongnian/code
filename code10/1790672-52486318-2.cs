    using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
                {
                    mysqlCon.Open();
                    MySqlCommand mysqlCmd = new MySqlCommand("MemberEditORAdd",mysqlCon);
                    mysqlCmd.CommandType = CommandType.StoredProcedure;
                    mysqlCmd.Parameters.AddWithValue("_IDFID", IDFID);
                    mysqlCmd.Parameters.AddWithValue("MemberName", MemberName.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MemberRank", MemberRank.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MemberWarn", MemberWarn.Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("MemberJoinDate", MemberJoinDate.Text.Trim());
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Operation Done!");
                }
