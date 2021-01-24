    [TestFixture]
    [Category(TestCategory.Integration)]
    public class ControllersResolutionTest
    {
        [Test]
        public void VerifyControllers()
        {
            var builder = new WebHostBuilder()
                .UseStartup<IntegrationTestsStartup>();
            var testServer = new TestServer(builder);
            var controllersAssembly = typeof(UsersController).Assembly;
            var controllers = controllersAssembly.ExportedTypes.Where(x => typeof(Controller).IsAssignableFrom(x));
            var activator = testServer.Host.Services.GetService<IControllerActivator>();
            var serviceProvider = testServer.Host.Services.GetService<IServiceProvider>();
            var errors = new Dictionary<Type, Exception>();
            foreach (var controllerType in controllers)
            {
                try
                {
                    var actionContext = new ActionContext(
                        new DefaultHttpContext
                        {
                            RequestServices = serviceProvider
                        },
                        new RouteData(),
                        new ControllerActionDescriptor
                        {
                            ControllerTypeInfo = controllerType.GetTypeInfo()
                        });
                    activator.Create(new ControllerContext(actionContext));
                }
                catch (Exception e)
                {
                    errors.Add(controllerType, e);
                }
            }
    
            if (errors.Any())
            {
                Assert.Fail(
                    string.Join(
                        Environment.NewLine,
                        errors.Select(x => $"Failed to resolve controller {x.Key.Name} due to {x.Value.ToString()}")));
            }
        }
    }
