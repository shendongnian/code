	protected void Application_Start()
	{
		RegisterRoutes(RouteTable.Routes);
		// custom controller factory that uses Windsor
		ControllerBuilder.Current.SetControllerFactory(
			new CastleWindsorControllerFactory());
		// Uncomment to debug routes
		//RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
	}
