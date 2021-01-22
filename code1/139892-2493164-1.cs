    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "MyRoute",
            MyArea/{controller}/{action}/{id},
            new {controller = "MyController", Action="Index" }
        );
    }
