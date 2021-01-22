            try
            {
                
                using (
                ServerManager serverManager = new ServerManager())
                {   
                    // connects to default app.config
                    var config = serverManager.GetApplicationHostConfiguration();
                    var staticContent = config.GetSection("system.webServer/staticContent");
                    var mimeMap = staticContent.GetCollection();
                    foreach (var mimeType in mimeMap)
                    {
                        if (((String)mimeType["fileExtension"]).Equals(fileExtension, StringComparison.OrdinalIgnoreCase))
                            return true;
                                                   
                    }
                   
                }
                return false;
            }
            catch (Exception ex)
            { 
                Console.WriteLine("An exception has occurred: \n{0}", ex.Message);
                Console.Read();
            }
            return false;
           
        }
