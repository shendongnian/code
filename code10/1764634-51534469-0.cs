    using Microsoft.SqlServer.Dts.Runtime;
    
    
    namespace ConsoleApplication8
    {
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
                  @"C:\Users\thoje\Documents\Visual Studio 2015\Projects\Integration Services Project8\Integration Services Project8\Package37.dtsx";
                app = new Application();
                pkg = app.LoadPackage(pkgLocation, eventListener);
                pkgResults = pkg.Execute(null,null,eventListener,null,null);
    
                Console.WriteLine(pkgResults.ToString());
                Console.ReadKey();
            }
        }
    
    
        class MyEventListener : DefaultEvents
        {
            public override bool OnError(DtsObject source, int errorCode, string subComponent,
                   string description, string helpFile, int helpContext, string idofInterfaceWithError)
            {
                // Output Error Message
                Console.WriteLine("Error in {0}/{1} : {2}", source, subComponent, description);
                return false;
            }
        }
    }
