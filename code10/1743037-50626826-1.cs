    public void Insert_Silver_Robot(String Program_S, String Grpup_S, DateTime Start_Date_S, String Start_Time_S, Decimal Pieces_S, DateTime Finish_Date_S, String Finish_Time_S, double Average_Part_Cycle_Time_S, String Mode_S, double Length_S, double Total_Time_S)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = con_str_S3;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Silver_Robot_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
    
    
                    cmd.Parameters.AddWithValue("@program", Program_S);
                    cmd.Parameters.AddWithValue("@group", Grpup_S);
                    cmd.Parameters.AddWithValue("@start_Date", Start_Date_S);
                    cmd.Parameters.AddWithValue("@start_time", Start_Time_S);
                    cmd.Parameters.AddWithValue("@pieces", Pieces_S);
                    cmd.Parameters.AddWithValue("@finish_date", Finish_Date_S);
                    cmd.Parameters.AddWithValue("@finish_time", Finish_Time_S);
                    cmd.Parameters.AddWithValue("@avarage_part", Average_Part_Cycle_Time_S);
                    cmd.Parameters.AddWithValue("@mode_p", Mode_S);
                    cmd.Parameters.AddWithValue("@length_p", Length_S);
                    cmd.Parameters.AddWithValue("@Total_Time_p", Total_Time_S);
    
                      //try
                    //{
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //}catch(Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                    //finally
                    //{
                    //    if(con.State==ConnectionState.Open)
                    //    {
                    conn.Close();
                    //  }
                    // }
                }
            }
