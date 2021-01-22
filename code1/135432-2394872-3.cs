    public class MyAspNetHost : System.MarshalByRefObject
    {
        public void ProcessRequest(string page)
        {
            var request = new System.Web.Hosting.SimpleWorkerRequest
                (page,               // the page being requested
                 null,               // query - none in this case
                 System.Console.Out  // output - any TextWriter will do
                );
 
            // this will emit the page output to Console.Out
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
            // ASPNET looks for assemblies - including the assembbly
            // that contains any custom ASPNET host - in the bin\
            // subdirectory of the physical directory that backs the
            // ASPNET Host.  Because we are going to use the current
            // working directory as the physical backing directory for
            // the ASPNET host, we need to ensure there's a bin
            // subdirectory present.
            bool cleanBin = false;
            if (!Directory.Exists("bin"))
            {
                cleanBin = true;
                Directory.CreateDirectory("bin");
            }
            // Now, ensure that the assembly containing the custom host is
            // present in that bin directory.  The assembly containing the
            // custom host is actually *this* assembly.  
            var a = System.Reflection.Assembly.GetExecutingAssembly();
            string destfile= Path.Combine("bin", Path.GetFileName(a.Location));
            File.Copy(a.Location, destfile, true); 
            host =
                (MyAspNetHost) System.Web.Hosting.ApplicationHost.CreateApplicationHost
                ( typeof(MyAspNetHost),
                  "/foo",   // virtual dir - can be anything
                  System.IO.Directory.GetCurrentDirectory() // physical dir
                  );
            // process each page
            foreach (string page in pages)
                host.ProcessRequest(page);
        }
    }
