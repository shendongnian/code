    routes.MapRoute(
                "Categories",
                "{category}/{action}",
                new { controller = "Categories", action = "Index" },
                new
                {
                    category=
                new FromValuesListConstraint("Category1", "Category2", "Category3", "Category4", "Category5")
                }
                );
    // all your default routing
    routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
