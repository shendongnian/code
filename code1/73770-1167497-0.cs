    protected void btnUpdateTable_Click(object sender, EventArgs e)
    { 
        Random rand = new Random;
        
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
           ///check if column[logout] is null or empty, fill it
           if(dr.IsNull("logout_time"))
           {
               ///get the login colum datetime
               /// add random datetime to it
               if (!dr.IsNull("login_time"))
               {
                   DateTime dt = Convert.ToDateTime(dr["login_time"]);
                   dt = dt.AddMinutes(rand.Next(0, (59 - dt.Minutes)));
               }            
           }
        }
    }
