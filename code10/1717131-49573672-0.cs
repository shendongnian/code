     if (!HttpContext.Current.User.Identity.IsAuthenticated )
                    {
                        HttpContext.Current.Response.Write("//No authenticated access to static files are allowed");
                        return;
                    }
    var requestedFile=File.ReadAllText(HttpContext.Current.Request.PhysicalPath);
       HttpContext.Current.Response.ContentType = "text/html";
                    HttpContext.Current.Response.Write(requestedFile);
