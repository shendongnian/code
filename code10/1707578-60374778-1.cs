	public class Program
	{
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				//...
				.UseDefaultServiceProvider((context, options) =>
				{
					options.ValidateOnBuild = false;
				});
