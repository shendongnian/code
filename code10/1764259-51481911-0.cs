    routes.MapRoute(
       "employee", "employee/{name}", new
       {
           controller = "Employee", action = "Search", name =UrlParameter.Optional }
                );
    
            }
        }
