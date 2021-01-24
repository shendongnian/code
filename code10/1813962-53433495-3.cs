    @using Microsoft.AspNetCore.Hosting
    @inject IHostingEnvironment environment
    @{
        string path = string.Format("js/page/{0}/{1}.js", controllerName, actionName);
    }
    @if (System.IO.File.Exists(System.IO.Path.Combine(environment.WebRootPath, path)))
    {
        <!-- file exist here... -->
    }
