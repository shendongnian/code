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
          int? persId = null;
          string siz,
          string place = "";
          string one_or_more = "";
          string r_or_l = "";
          string eko_or_ash = "";
          string notice = "";
          while (sqlReader.Read())
          {
              persId = sqlReader["ID"] as int? ?? default(int);
              siz = sqlReader["SIZ"] as string;
              place = sqlReader["PLACE"] as string;
              one_or_more = sqlReader["ONE_OR_MORE"] as string;
              r_or_l = sqlReader["R_OR_L"] as string;
              eko_or_ash = sqlReader["EKO_OR_ASH"] as string;
              notice = sqlReader["NOTICE"] as string;
          }
          PersonificationID = persId ?? 0; //null coalesce
          TB_Size.Text = siz;
          CB_TreatmentPlace.SelectedValue = place;
          CB_GravelCount.SelectedValue = one_or_more;
          CB_Side.SelectedValue = r_or_l;
          CB_TreatmentWay.SelectedValue = eko_or_ash;
          TB_Note.Text = notice;
          return 1;
        }
        catch (Exception ex)
        {
          //Read the exception message using your debugger.
          return 0;
        }
      }
    }
