    public int GetPersonification()
    {
        string connStr = ConfigurationManager.ConnectionStrings["SRJDconnstr"].ToString();
        string cmdStr = @"SELECT ID,
                                SIZ,
                              PLACE,
                        ONE_OR_MORE,
                             R_OR_L,
                         EKO_OR_ASH,
                             NOTICE
               FROM PERSONIFICATION
               WHERE SEANCE_ID=@SEANCE_ID;";
    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
    {
      //Add the try here
      try
      {
        conn.Open();
        cmd.CommandText = cmdStr;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@SEANCE_ID", SqlDbType.Int)).Value = F0102.vSessionID;
        SqlDataReader sqlReader = cmd.ExecuteReader();
        while (sqlReader.Read())
        {
            PersonificationID = Convert.ToInt32(sqlReader[0].ToString());
            TB_Size.Text = sqlReader[1].ToString();                              //SIZ
            CB_TreatmentPlace.SelectedValue = sqlReader[2].ToString(); //PLACE
            CB_GravelCount.SelectedValue = sqlReader[3].ToString();      //ONE_OR_MORE
            CB_Side.SelectedValue = sqlReader[4].ToString();                 //R_OR_L
            CB_TreatmentWay.SelectedValue = sqlReader[5].ToString(); //EKO_OR_ASH
            TB_Note.Text = sqlReader[6].ToString();                             //NOTICE
        }
        return 1;
      }
      catch (Exception ex)
      {
        //Read the exception message using your debugger.
        return 0;
      }
    }
}
