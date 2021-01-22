        public static string TestMethod(DataTable dt)
        {
            string connString = "";
            string errorMsg = string.Empty;
            try
            {
                //loop through each row of the datatable. Not sure if the column names is a row.
                foreach (DataRow row in dt.Rows)
                {
                    using (SqlConnection conn2 = new SqlConnection(connString))
                    {
                        using (SqlCommand cmd = conn2.CreateCommand())
                        {
                            cmd.CommandText = "dbo.AppendDataCT";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = conn2;
                            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@col1", SqlDbType = SqlDbType.VarChar, Value = row[0] });
                            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@col2", SqlDbType = SqlDbType.VarChar, Value = row[1] });
                            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@col3", SqlDbType = SqlDbType.VarChar, Value = row[2] });
                            conn2.Open();
                            cmd.ExecuteNonQuery();
                            conn2.Close();
                        }
                    }                
                }
                errorMsg = "The Person.ContactType table was successfully updated!";
            }
            catch
            {
            }
            return errorMsg;
        }
