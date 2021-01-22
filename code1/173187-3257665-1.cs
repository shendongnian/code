	public class MvcApplication : NinjectHttpApplication
	{
		protected override void OnApplicationStarted() {
			RegisterRoutes(RouteTable.Routes);
			RegisterAllControllersIn(Assembly.GetExecutingAssembly());
		}
		protected override IKernel CreateKernel() {
			var modules = new INinjectModule[] {
				new MyProject.Services.ServiceModule(),
				new MyProject.Data.DataModule()
			};
			var kernel = new StandardKernel(modules);
			return kernel;
		}
