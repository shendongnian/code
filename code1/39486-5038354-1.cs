    protected void Page_Load(object sender,EventArgs e)
    {
       if(Session["CallParent"]!=null)
       {
          // here call the Parent Page method 
          Method1();
          // now make the session value null
         Session["CallParent"]=null;
        }
    }
