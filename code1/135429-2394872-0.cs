    public class MyAspNetHost : System.MarshalByRefObject
    {
        public void ProcessRequest(string page)
        {
            var request = new System.Web.Hosting.SimpleWorkerRequest
                (page,               // page being requested
                 null,               // query
                 System.Console.Out  // output
                                                                     );
            System.Web.HttpRuntime.ProcessRequest(request);
        }
        public AppDomain GetAppDomain()
        {
            return System.Threading.Thread.GetDomain();
        }
    }
    public class Example
    {   
        public void Run(IEnumerable<String> pages)
        {
            if (!Directory.Exists("bin"))
            {
                Directory.CreateDirectory("bin");
            }
            var a = System.Reflection.Assembly.GetExecutingAssembly();
            string destfile= Path.Combine("bin", Path.GetFileName(a.Location));
            File.Copy(a.Location, destfile, true); 
            host =
                (MyAspNetHost) System.Web.Hosting.ApplicationHost.CreateApplicationHost
                ( typeof(MyAspNetHost),
                  "/foo",   // virtual dir - can be anything
                  System.IO.Directory.GetCurrentDirectory() // physical dir
                  );
            aspNetHostIsUnloaded = new ManualResetEvent(false);
            host.GetAppDomain().DomainUnload += this.HostedDomainHasBeenUnloaded;
            foreach (string page in pages)
                host.ProcessRequest(page);
        }
    }
