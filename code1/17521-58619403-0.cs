        Package pkg;
        Microsoft.SqlServer.Dts.Runtime.Application app;
        DTSExecResult pkgResults;
        Variables vars;
        app = new Microsoft.SqlServer.Dts.Runtime.Application();
        pkg = app.LoadPackage(" Location of your SSIS package", null);
        vars = pkg.Variables;
        // your variables
        vars["somevariable1"].Value = "yourvariable1";
        vars["somevariable2"].Value = "yourvariable2";
        pkgResults = pkg.Execute(null, vars, null, null, null);
        if (pkgResults == DTSExecResult.Success)
        {
            Console.WriteLine("Package ran successfully");
        }
        else
        {
            
            Console.WriteLine("Package failed");
        }
   
