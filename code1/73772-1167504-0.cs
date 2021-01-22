    protected void btnUpdateTable_Click(object sender, EventArgs e) { 
        foreach (DataRow dr in ds.Tables[0].Rows)
           if(dr.IsNull("logout_time") && !dr.IsNull("login_time")) {
              DateTime loginTime = Convert.ToDateTime(dr["login_time"]);
              loginTime = loginTime.AddMinutes(new Random().Next(0,59));
           }
    }
