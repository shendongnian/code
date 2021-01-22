    	public class ProjectRegistry : Registry
	{
		public ProjectRegistry()
		{
			IncludeRegistry<CommonsRegistry>();
			Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.WithDefaultConventions();
			});
		}
	}
