    public class MyControllerFactory : DefaultControllerFactory
    {
		protected override IController GetControllerInstance(Type controllerType)
		{
			IController result = null;
			// Try and load the controller, based on the controllerType argument.
			// ... snip
			// Did we retrieve a controller?
			if (controller == null)
			{
				result = new MyCustomController();
				requestContext.RouteData.Values["action"] = "My404Action";
			}
			return result;
		}
    }
