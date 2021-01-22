    protected DataTable RetrieveEmployeeSubInfo(string employeeNo)
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                try
                {
                    cmd = new SqlCommand("RETRIEVE_EMPLOYEE", pl.ConnOpen());
                    cmd.Parameters.Add(new SqlParameter("@EMPLOYEENO", employeeNo));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.GetBaseException().ToString(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    pl.MySQLConn.Close();
                }
                return dt;
            }
