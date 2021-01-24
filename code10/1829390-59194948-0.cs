var host = new WebHostBuilder()
     .UseConfiguration(config)
      // ...
     .Build();
using (var subscription = InitializeSqlSubscription(host))
{
  host.Run();
}
private static IDisposable InitializeSqlSubscription(IWebHost host)
{
   // TODO: remove Workaround with .Net Core 3.1
   // we need a scope for the ServiceProvider
   using (var serviceScope = host.Services.CreateScope())
   {
      var services = serviceScope.ServiceProvider;
      try
      {
         var adapter = new DbCommandAdapter();
         // context needed to get DiagnosticSource (EntityFramework)
         var myContext = services.GetRequiredService<MyContext>();
         // DiagnosticSource is Singleton in ServiceProvider (i guess), and spanning across scopes
         // -> Disposal of scope has no effect on DiagnosticSource or its subscriptions
         var diagnosticSource = myContext.GetService<DiagnosticSource>();
         // adapter Object is referenced and kept alive by the subscription
         // DiagnosticListener is Disposable, but was created (and should be disposed) by ServiceProvider
         // subscription itself is returned and can be disposed at the end of the application lifetime
         return (diagnosticSource as DiagnosticListener).SubscribeWithAdapter(adapter);
      }
      catch (Exception ex)
      {
         var logger = services.GetRequiredService<ILogger<Startup>>();
         logger.LogError(ex, "An error occurred while initializing subscription");
         throw;
      }
   }
}
