    // \packages\microsoft.aspnetcore.hosting.abstractions\2.2.0\lib\netstandard2.0\Microsoft.AspNetCore.Hosting.Abstractions.dll
    namespace Microsoft.AspNetCore.Hosting
    {
     public interface IStartup
      {
       IServiceProvider ConfigureServices(IServiceCollection services);
       void Configure(IApplicationBuilder app);
      }
    }
    
