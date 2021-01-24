    public class Functions
    {
	    public static Lazy<ILifetimeScope> LifetimeScope { get; set; } = new Lazy<ILifetimeScope>(CreateContainer);
	    private static ILifetimeScope CreateContainer()
	    {
		    var containerBuilder = new ContainerBuilder();
		    containerBuilder.RegisterType<ServerAbc>()
				.AsImplementedInterfaces();
		    return containerBuilder.Build();
	    }
		
		/// <summary>
		/// A Lambda function
		/// </summary>
		public async Task Handle(ILambdaContext context)
		{
			using (var innerScope = LifetimeScope.Value.BeginLifetimeScope())
			{
				var service = innerScope.Resolve<IServerAbc>();
				await service.GoDoWork()
					.ConfigureAwait(false);
			}
		}
    }
