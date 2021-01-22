	internal class ServiceWrapper
	{
		Service Svc;
		public ServiceWrapper()
		{
			Svc = ServiceClient();
		}
		[System.Security.Permissions.PrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Role = "HelloWorld")]
		public string HelloWorld()
		{
			return Svc.HelloWorld();
		}
	}
