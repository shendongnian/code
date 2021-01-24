      public void checkUserType()
    {
        String CS = ConfigurationManager.ConnectionStrings["BoothsConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["YourUserTypeColumnName"] == "U")
                {
                    userhome.Visible = true;
                    adminpanel.Visible = false;
                }
                if (dr["YourUserTypeColumnName"] == "A")
                {
                    adminpanel.Visible = true;
                    userhome.Visible = false;
                }
            }
        }
    }
