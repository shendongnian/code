    string temp="";
    for (int i = 1; i <= daysCount; i++)
    {
      if(i!=1)
       temp+=",";
      temp+="('" + lblDate1.Text + "','" + txtFuel1.Text+ "','" + txtRate1.Text + "')";
    }
        conn.Open();
        string sQuery = "INSERT INTO TripSheet VALUES "+temp;
        SqlCommand cmd = new SqlCommand(sQuery, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
