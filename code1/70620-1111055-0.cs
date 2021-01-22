    if(Authenticated)
    {
        string path = Request.UrlReferrer.AbsolutePath;
        if (path.EndsWith("/tools/NonMember.aspx"))
        {
            Response.Redirect("~/tools/Member.aspx");
        }
    }
                  
