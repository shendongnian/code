    Query = "UPDATE Person SET Person_Image =@pic  WHERE (Person_NIC = '" + NIC_Box.Text.Trim() + "')";
                        SqlCommand cmd = new SqlCommand(Query);
                        SqlParameter picparameter = new SqlParameter();
                        picparameter.SqlDbType = SqlDbType.Image;
                        picparameter.ParameterName = "pic";
                        picparameter.Value = ms.GetBuffer();
                        cmd.Parameters.Add(picparameter);
                        
                        db.ExecuteSQL(Query);
