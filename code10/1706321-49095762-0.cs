    try
    {
        string lastdatetime = null;
                        string Connectionstring = ConfigurationManager.ConnectionStrings["DbLogns"].ToString();
                        SqlConnection objConection = new SqlConnection(Connectionstring);
                        objConection.Open();
                        SqlCommand objCommand = new SqlCommand("select LastEditTime from Userdatatext where UserName='" + Session["userName"] + "'", objConection);
                        SqlDataReader dr = objCommand.ExecuteReader();
                        if (dr.Read())
                        {
                             lastdatetime = dr["LastEditTime"].ToString();
                        }
                        dr.Close();          
                        Lbllastedit.Text = "Last edit on :-" + lastdatetime;
                        Lbllastedit.Font.Size = 15;
                        objConection.Close();
    }
