            string cnStr = "Server=.;Database=Sandbox;Integrated Security=sspi;";
            using (SqlConnection cn = new SqlConnection(cnStr)) {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("TestProc", cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);
                    cmd.ExecuteNonQuery();
                    Assert.AreEqual(123, (int)returnValue.Value);
                }
            }
