    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
          if (custom == "userid")
          {
             if (context.Session["userid"] != null)
                  return context.Session["userid"].ToString();
    
              return string.Empty;
           }
           return base.GetVaryByCustomString(context, custom);
    }
