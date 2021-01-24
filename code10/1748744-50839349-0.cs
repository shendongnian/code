	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.MapRoute(
			name: "Artikel",
			url: "artikel/{id}",
			defaults: new { controller = "Artikel", action = "Index", id = UrlParameter.Optional }
		);
		//default and other routes go here, after Artikel
	}
