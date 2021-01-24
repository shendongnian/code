	public class CustomControllerFactory : IControllerFactory
	{
		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			var ns = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
			var coreNs = $"{ns}.Core.Controllers";
			var clientNs = $"{ns}.Client.Controllers";
			//find out if core or client exists: https://stackoverflow.com/questions/8499593/c-sharp-how-to-check-if-namespace-class-or-method-exists-in-c
			var coreControllers = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
								   from type in assembly.GetTypes()
								   where type.Namespace == coreNs
								   select type);
			var clientControllers = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
									 from type in assembly.GetTypes()
									 where type.Namespace == clientNs
									 select type);
			Type controllerFullType = null;
			if (coreControllers.Any(x => x.Name == $"{controllerName}Controller"))
			{
				controllerFullType = Type.GetType($"{ns}.Core.Controllers.{controllerName}Controller");
			}
			else if (clientControllers.Any(x => x.Name == $"{controllerName}Controller"))
			{
				controllerFullType = Type.GetType($"{ns}.Client.Controllers.{controllerName}Controller");
			}
			else
			{
				throw new ApplicationException("no valid controller found");
			}
			IController controller = Activator.CreateInstance(controllerFullType) as Controller;
			return controller;
		}
		public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
		{
			return SessionStateBehavior.Default;
		}
		public void ReleaseController(IController controller)
		{
			(controller as IDisposable)?.Dispose();
		}
	}
