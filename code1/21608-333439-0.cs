    public void Init(HttpApplication context)
    {
      context.BeginRequest += new EventHandler(BeginRequest);
    }
    
    void BeginRequest(object sender, EventArgs e)
    {
    
      HttpContext context = HttpContext.Current;
      HttpRequest request = context.Request;
    
      string requestPath = HttpContext.Current.Request.Url.AbsolutePath;
      string extension = System.IO.Path.GetExtension(requestPath);
      bool isAspx = extension.Equals(".aspx");
    
      if (isAspx)
      {
        // Add whatever you need of custom logic for adding the content here
        context.Items["custom"] = "anything here";
      }
    
    }
