    using (SqlConnection sqlCon = new SqlConnection(Main.connectionString))
                        {
                            string commandString = "SELECT TOP 1 FORMAT(Due_Date,'dd-MM-yyyy') as Due_Date FROM Transactions where Plot_Code='" + Plot_Code_var + "' ORDER BY Due_Date DESC;";
    
                            SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                            sqlCon.Open();
                            SqlDataReader dr = sqlCmd.ExecuteReader();
                            while (dr.Read())
                            {
                                date_control_var = 2;
                                Due_Date_Sample = (dr["Due_Date"].ToString());
                                Due_Date_var = DateTime.Parse(Due_Date_Sample.ToString());
    
                            }
                            dr.Close();
                        }
