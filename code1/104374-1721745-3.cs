    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Forum_Default",
            "Forum/{controller}/{action}/{Id}",
             new { controller = "Forum", action = "Index"}
        );
    }
