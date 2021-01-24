     /// <summary>
        /// A test fixture which hosts the target project (project we wish to test) in an in-memory server.
        /// </summary>
        /// <typeparam name="TStartup">Target project's startup type</typeparam>
        /// <typeparam name="DStartup">Decorated startup type</typeparam>
        public class TestFixture<DStartup, TStartup> : IDisposable
        {
            private readonly TestServer _server;
    
            public TestFixture()
                : this(Path.Combine("YourRelativeTargetProjectParentDir"))
            {
            }
    
            protected TestFixture(string relativeTargetProjectParentDir)
            {
                var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
                var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);
    
                //var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
                //var contentRoot = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../MinasTirith"));
                var builder = new WebHostBuilder()
                    .UseContentRoot(contentRoot)
                    .ConfigureServices(InitializeServices)
                    .UseEnvironment("Development")
                    .UseStartup(typeof(DStartup));
    
                _server = new TestServer(builder);
    
                Client = _server.CreateClient();
                Client.BaseAddress = new Uri("http://localhost:5000");
            }
    
            public HttpClient Client { get; }   
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                Client.Dispose();
                _server.Dispose();
            }
    
    
            protected virtual void InitializeServices(IServiceCollection services)
            {
                var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
    
                // Inject a custom application part manager. 
                // Overrides AddMvcCore() because it uses TryAdd().
                var manager = new ApplicationPartManager();
                manager.ApplicationParts.Add(new AssemblyPart(startupAssembly));
                manager.FeatureProviders.Add(new ControllerFeatureProvider());
                manager.FeatureProviders.Add(new ViewComponentFeatureProvider());
    
                services.AddSingleton(manager);
            }
    
            /// <summary>
            /// Gets the full path to the target project that we wish to test
            /// </summary>
            /// <param name="projectRelativePath">
            /// The parent directory of the target project.
            /// e.g. src, samples, test, or test/Websites
            /// </param>
            /// <param name="startupAssembly">The target project's assembly.</param>
            /// <returns>The full path to the target project.</returns>
            private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
            {
                // Get name of the target project which we want to test
                var projectName = startupAssembly.GetName().Name;
    
                // Get currently executing test project path
                var applicationBasePath = System.AppContext.BaseDirectory;
    
                // Find the path to the target project
                var directoryInfo = new DirectoryInfo(applicationBasePath);
                do
                {
                    directoryInfo = directoryInfo.Parent;
    
                    var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                    if (projectDirectoryInfo.Exists)
                    {
                        var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
                        if (projectFileInfo.Exists)
                        {
                            return Path.Combine(projectDirectoryInfo.FullName, projectName);
                        }
                    }
                }
                while (directoryInfo.Parent != null);
    
                throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
            }
        }
