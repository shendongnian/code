    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    private readonly IConfigurationRoot _appConfiguration;
    private readonly IHostingEnvironment _hostingEnvironment;
    
    public Startup(IHostingEnvironment env)
    {
    	_hostingEnvironment = env;
    	_appConfiguration = env.GetAppConfiguration();
    }
