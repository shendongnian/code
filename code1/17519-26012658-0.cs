    using System;
    using Microsoft.SqlServer.Dts.Runtime;
    
    namespace RunFromClientAppWithEventsCS
    {
      class MyEventListener : DefaultEvents
      {
        public override bool OnError(DtsObject source, int errorCode, string subComponent, 
          string description, string helpFile, int helpContext, string idofInterfaceWithError)
        {
          // Add application-specific diagnostics here.
          Console.WriteLine("Error in {0}/{1} : {2}", source, subComponent, description);
          return false;
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          string pkgLocation;
          Package pkg;
          Application app;
          DTSExecResult pkgResults;
    
          MyEventListener eventListener = new MyEventListener();
    
          pkgLocation =
            @"C:\Program Files\Microsoft SQL Server\100\Samples\Integration Services" +
            @"\Package Samples\CalculatedColumns Sample\CalculatedColumns\CalculatedColumns.dtsx";
          app = new Application();
          pkg = app.LoadPackage(pkgLocation, eventListener);
          pkgResults = pkg.Execute(null, null, eventListener, null, null);
    
          Console.WriteLine(pkgResults.ToString());
          Console.ReadKey();
        }
      }
    }
