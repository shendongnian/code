     public void Update()
            {
                var con = new SqlConnection();
                try
                {
    
                    var empId = TxtEMPID.Text
                    var avayaId = TxtAvayaID.Text
                    con.Open();
    
                    var cmd1 = new SqlCommand("update Comcast_AvayaID set Status='Inactive' where Employee_Id=@empId and AvayaID = @avayaId", con);              
                    cmd1.Parameters.Add(AddParameter("@empId",empId));
                    cmd1.Parameters.Add(AddParameter("@avayaId", avayaId));
    
                    var cmd2 = new SqlCommand("UPDATE Avaya_Id SET Status = 'UnAssigned' where Avaya_ID =avayaId", con);
                    cmd2.Parameters.Add(AddParameter("@avayaId", avayaId));
    
                    var rowsaffected1 = cmd1.ExecuteNonQuery();
    
                    var rowsAffected2 = cmd2.ExecuteNonQuery();
    
                    if (rowsaffected1 == 1 && rowsAffected2 == 1)
                    {
                        //success code goes here
                        //--------
                        LBLSuccess.Visible = true;
                        LBLSuccess.Text = "Deactivation Successfull";
                    }
                    else
                    {
                        // failure code goes here
                        //-----------------------
                        LBLSuccess.Visible = true;
                        LBLSuccess.Text = "Deactivation Unsuccessfull";
                    }
                }
                catch (SqlException ex)
                {
                    //handle errors
                }
                finally
                {
                    con.Close();
                }
    
    
                Console.ReadLine();
            }
    
            private SqlParameter AddParameter(string name, object value) {
                var par = new SqlParameter();
                par.ParameterName = name;
                par.Value = value;
                return par;
            }
