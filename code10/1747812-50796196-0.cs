    [TestFixture]
    public class ControllersResolutionTest
    {
        [Test]
        public void VerifyControllers()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>(); //use Sturtup or some derived 
                                        //class that is integration tests friendly
            var testServer = new TestServer(builder);
            var controllersAssembly = typeof(UsersController).Assembly;
            var controllers = controllersAssembly.ExportedTypes
                   .Where(x => typeof(Controller).IsAssignableFrom(x));
            var errors = new Dictionary<Type, Exception>();
            foreach (var controllerType in controllers)
            {
                try
                {
                    testServer.Host.Services.GetService(controllerType);
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
                        errors.Select(x => 
        $"Failed to resolve controller {x.Key.Name} due to {x.Value.ToString()}")));
            }
        }
    }
