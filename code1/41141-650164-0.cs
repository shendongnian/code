      public void Init(HttpApplication context)
      {
        context.BeginRequest += new EventHandler(context_BeginRequest);
      }
    
      void context_BeginRequest(object sender, EventArgs e)
      {
        HttpContext context = ((HttpApplication)sender).Context;
        if (context.Request.RawUrl.ToLowerInvariant().Equals("YOURSEOURL"))
          context.RewritePath("YOURNONSEOURL");
      }
