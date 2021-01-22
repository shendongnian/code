    var page = new Page();
    var writer = new StringWriter();            
    page.PreInit += new EventHandler((s, e) =>
    {
        var control = page.LoadControl("");
        (Page)s).Controls.Add(control);
    });
    HttpContext.Current.Server.Execute(page, writer, false);
