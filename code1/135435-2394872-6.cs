        private ManualResetEvent aspNetHostIsUnloaded;
        private void HostedDomainHasBeenUnloaded(object source, System.EventArgs e)
        {
            // cannot clean bin dir here.  The AppDomain is not yet gone.
            aspNetHostIsUnloaded.Set();
        }
        private Run(IEnumerable<String> pages)
        {
            try 
            {
                ....code from above ....
            }
            finally
            {
                if (host!= null)
                {
                    aspNetHostIsUnloaded = new ManualResetEvent(false);
                    host.GetAppDomain().DomainUnload += this.HostedDomainHasBeenUnloaded;
                    AppDomain.Unload(host.GetAppDomain());
                    // wait for it to unload
                    aspNetHostIsUnloaded.WaitOne();
                    // optionally remove the bin directory
                    if (cleanBin)
                    {
                        Directory.Delete("bin", true);
                    }
                    aspNetHostIsUnloaded.Close();
                }
            }
        }
