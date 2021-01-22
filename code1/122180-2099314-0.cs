    routes.MapRoute(
             "",
             "{UserName}/{action}",
             new { controller="User", action="Index", UserID=user.UserID }
         );
