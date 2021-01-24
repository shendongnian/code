    bool CheckDuplicateFlight(int FLIGHT_ID)
    {
    SqlConnection con = new SqlConnection();
    con.ConnectionString = @"YOURCONNECTION STRING";
    con.Open();
    if (con.State == System.Data.ConnectionState.Open)
    {
    SqlCeCommand cmd = new SqlCeCommand("select count(*) from YOURTABLE where FLIGHT_ID= @FLIGHT_ID", con);
    cmd.Connection = con;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.Parameters.AddWithValue("@FLIGHT_ID",FLIGHT_ID);
    int ExistingId= Convert.ToInt32(cmd.ExecuteScalar());
    }
    con.Close();
    if(ExistingId> 0)
        return true;
    return false;
    }
    if(CheckDuplicateFlight(FLIGHT_ID))
    {
    ///// Your insertion/Update Code here
    }
