    using Microsoft.SqlServer.Dts.Runtime;
    private void Execute_Package()
        {           
            string pkgLocation = @"c:\test.dtsx";
 
            Package pkg;
            Application app;
            DTSExecResult pkgResults;
            Variables vars;
 
            app = new Application();
            pkg = app.LoadPackage(pkgLocation, null);
 
            vars = pkg.Variables;
            vars["A_Variable"].Value = "Some value";               
           
            pkgResults = pkg.Execute(null, vars, null, null, null);
            if (pkgResults == DTSExecResult.Success)
                Console.WriteLine("Package ran successfully");
            else
                Console.WriteLine("Package failed");
        }
