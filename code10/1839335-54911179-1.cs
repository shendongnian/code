public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
        .ConfigureServices(serviceCollection => serviceCollection
                .Configure<AzureFileLoggerOptions>(options => {
                    options.FileName = "azure-diagnostics-";
                    options.FileSizeLimit = 50 * 1024;
                    options.RetainedFileCountLimit = 5;
                }).Configure<AzureBlobLoggerOptions>(options => {
                    options.BlobName = "log.txt";
                }))
        .UseStartup<Startup>();
This requires the NuGet package `Microsoft.Extensions.Logging.AzureAppServices` and the following using statements:
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.AzureAppServices;
using Microsoft.Extensions.Logging;
