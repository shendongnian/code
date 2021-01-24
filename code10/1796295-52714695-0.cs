    AuthenticationManager authManager = new AuthenticationManager();
    using (var context = authManager.GetWebLoginClientContext(URI))
    {
        context.Load(context.Web, web => web.Title);
        context.ExecuteQuery();
        Console.WriteLine("Your site title is: " + context.Web.Title);
    }
