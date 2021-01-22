    public static dynamic GetSomeData(ParameterDTO dto)
            {
                dynamic result = null;
                string SPName = "a_legacy_stored_procedure";
                using (SqlConnection connection = new SqlConnection(DataConnection.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SPName, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;                
                    command.Parameters.Add(new SqlParameter("@empid", dto.EmpID));
                    command.Parameters.Add(new SqlParameter("@deptid", dto.DeptID));
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dynamic row = new ExpandoObject();
                            row.EmpName = reader["EmpFullName"].ToString();
                            row.DeptName = reader["DeptName"].ToString();
                            row.AnotherColumn = reader["AnotherColumn"].ToString();                        
                            result = row;
                        }
                    }
                }
                return result;
            }
