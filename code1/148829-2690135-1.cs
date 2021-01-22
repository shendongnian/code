    routes.MapRoute(
        "Thumbs", // Route name
        "Galleries/getThumb/{image}", // URL with parameters
         new { controller = "Gallery", action = "getThumb", id = UrlParameter.Optional }, // Parameter defaults
          new string[] { "TestArtist.Controllers" }
     );
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
         new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
    );
