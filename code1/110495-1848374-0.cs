    routes.MapRoute(
        "Systems_Default",
        "System/{systemName}/{action}",
        new { controller="System", action = "RouteSystem", systemName="" }
    );
