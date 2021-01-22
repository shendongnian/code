       routes.MapRoute(
                "AdminUserRoute",                     // Route name
                "admin/user/{action}/{id}",           // URL with parameters
            new { controller = "AdminUser", action = "Index", id = "" } 
        );
       routes.MapRoute(
                "AdminWorkRoute",                    // Route name
                "admin/work/{action}/{id}",          // URL with parameters
            new { controller = "AdminWork", action = "Index", id = "" }                
        );
