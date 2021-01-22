     public class DataImportService : ServiceBase
     {
         // ----------- Other code -----------
         static void Main(string[] args)
         {
           if (args.Length == 0) 
           {
                InstallService(false, argValue); break;
                StartService();
           }
           else
           {
                string arg0 = args[0],
                switchVal = arg0.ToUpper(),
                argValue = arg0.Contains(":") ?
                arg0.Substring(arg0.IndexOf(":")) : null;
        
                switch (switchVal.Substring(0, 1))
                {
                    //Install Service and run
                    case ("I"): case ("-I"): case ("/I"):
                        InstallService(true, argValue); break;
        
                     // Start Service
                    case ("S"): case ("-S"): case ("/S"):
                        StartService();
                    default: break;
      
                     // Install & Start Service
                    case ("IS"): case ("-IS"): case ("/IS"):
                        InstallService(false, argValue); break;
                        StartService();
                    // Uninstall Service
                    case ("U"): case ("-U"): case ("/U"):
                        InstallService(false, argValue); break;
                    default: break;                   
                }
            }
         private static void InstallService(bool install,  string argFileSpec)
         {
            string fileSpec = Assembly.GetExecutingAssembly().Location;
            if (!String.IsNullOrEmpty(argFileSpec)) fileSpec = argFileSpec;
            // ------------------------------------------------------------
            string[] installerParams =
                install? new string[] { fileSpec } :
                         new string[] { "/u", fileSpec };
            ManagedInstallerClass.InstallHelper(installerParams);
         }
         private void StartService()
         {
            var ctlr  = new ServiceController();
            ctlr.ServiceName = "MyService";    // hard code the service name
            // Start the service
            ctlr.Start();           
         }
    }
