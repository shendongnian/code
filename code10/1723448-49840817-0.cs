    public Employee GetEmployee(int id)
            {
            
                Employee emp = new Employee();
            
                using (SqlConnection con = db.Getconnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Sp_GetEmployeeById", con);
                    cmd.Parameters.AddWithValue("", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            emp.Emp_Id = Convert.ToInt32(rdr["Emp_Id"]);
                            emp.EmpName = rdr["EmpName"].ToString();
                            emp.Email = rdr["Email"].ToString();
                            emp.Cnt_Id = Convert.ToInt32(rdr["Cnt_Id"]);
                            }
                    }    
            }
               return emp;
        }
