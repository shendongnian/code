        public void Run(string[] pages)
        {
            bool cleanBin = false;
            MyAspNetHost host = null;
            try
            {
                // This creates a symlink.
                // ASPNET always looks for a bin\ directory for the privateBinPath of the AppDomain.
                // This will create the bin dir, pointing to the current dir.
                if (!Directory.Exists("bin"))
                {
                    cleanBin = true;
                    CreateSymbolicLink("bin", ".", 1);
                }
                host =
                    (MyAspNetHost) System.Web.Hosting.ApplicationHost.CreateApplicationHost
                    ( typeof(MyAspNetHost),
                      "/foo",   // virtual dir - can be anything
                      System.IO.Directory.GetCurrentDirectory() // physical dir
                      );
                foreach (string page in pages)
                    host.ProcessRequest(page);
            }
            finally
            {
                // tell the host to unload
                if (host!= null)
                {
                    AppDomain.Unload(host.GetAppDomain());
                    if (cleanBin)
                    {
                        // remove symlink - can do without waiting for AppDomain unload
                        Directory.Delete("bin");
                    }
                }
            }
        } 
