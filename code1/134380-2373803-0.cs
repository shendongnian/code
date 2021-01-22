    public override string GetVaryByCustomString(HttpContext context, string arg)
    {
        if(arg == "mySessionVar" && Session["mySessionVar"] != null)
        {
            return Session["mySessionVar"].ToString();
        }
    
         return base.GetVaryByCustomString(context, arg);
    }
    
