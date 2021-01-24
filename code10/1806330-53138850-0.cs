                string query2 = "SELECT * FROM [EmployeeLeaveHistory$]";
                using (OleDbCommand cmd2 = new OleDbCommand(query2, conn))
                {
                  using (OleDbDataReader dr2 = cmd2.ExecuteReader())
                    {
                              
                        string constring = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                        using (SqlCeConnection con = new SqlCeConnection(constring))
                        {
                            con.Open();
                            string del = "DELETE FROM EMPLOYEELEAVEHISTORY";
                            using (SqlCeCommand delete = new SqlCeCommand(del))
                            {
                                delete.Connection = con;
                                delete.ExecuteNonQuery();
                            }
                            using (SqlCeBulkCopy copy = new SqlCeBulkCopy(con))
                            {
                                copy.DestinationTableName = "EMPLOYEELEAVEHISTORY";
                                copy.ColumnMappings.Add("Emp_Num", "EmployeeNum");
                                copy.ColumnMappings.Add("Emp_Name", "EmployeeName");
                                copy.WriteToServer(dr2);
                            }
                        }
                    }
                }
