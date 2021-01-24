                string mode = "";
    
    #if DEVELOPMENT
                mode  = "DEVELOPMENT";
    #elif DEBUG
                mode = "DEBUG";
    #elif RELEASE
                 mode = "RELEASE";
    #endif
                
                switch (mode.ToUpper())
                {
                    case "DEVELOPMENT":
                    //Programmatically force the application to use the Development environment.
                        CreateWebHostBuilder(args).UseEnvironment("Development").Build().Run();
                        break;
                    default:
                        CreateWebHostBuilder(args).Build().Run();
                        break;
                }
