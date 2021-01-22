    protected void Page_Load(object sender, EventArgs e) {
        string username = Request["usr"];
        int r = 0;
    
        if(!String.IsNullorEmpty(username))
            if( yourDAL.getUserAvailability(username) )
                // your method would send true if user is available to be used
                r = 1;
       Response.Clear();
       Response.Write(r);
       Response.Flush();
    }
