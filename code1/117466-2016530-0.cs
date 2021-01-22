    	public class ApplicationBootstraper
	{
		public IContainer Container { get; set; }
		public ApplicationBootstraper()
		{
			Container = new Container(x=>
			{
				x.AddRegistry<SettingsRegistry>();
				x.AddRegistry<ProjectRegistry>();
				//more registries go here or application specific configuration.
			});
		}
	}
