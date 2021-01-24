  .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
        logging.AddDebug();
        logging.AddEventSourceLogger();
        logging.AddAzureWebAppDiagnostics();
    })
Add this to ConfigureServices in Startup.cs:
services.Configure<AzureFileLoggerOptions>(options =>
{
options.FileName = "azure-diagnostics-";
options.FileSizeLimit = 50 * 1024;
options.RetainedFileCountLimit = 5;
});
This was enough for me to start seeing messages in the Azure App Service log; you need the Nuget package `Microsoft.Extensions.Logging.AzureAppService` and corresponding using statements also:
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.AzureAppServices;
