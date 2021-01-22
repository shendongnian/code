    using System;
    using Microsoft.SqlServer.Dts.Runtime;
    
    namespace RunFromClientAppCS
    {
      class Program
      {
        static void Main(string[] args)
        {
          string pkgLocation;
          Package pkg;
          Application app;
          DTSExecResult pkgResults;
    
          pkgLocation =
            @"C:\Program Files\Microsoft SQL Server\100\Samples\Integration Services" +
            @"\Package Samples\CalculatedColumns Sample\CalculatedColumns\CalculatedColumns.dtsx";
          app = new Application();
          pkg = app.LoadPackage(pkgLocation, null);
          pkgResults = pkg.Execute();
    
          Console.WriteLine(pkgResults.ToString());
          Console.ReadKey();
        }
      }
    }
