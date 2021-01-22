    using System;
    using System.Diagnostics;
    using System.Web;
    ...
        
    // settings
    string PortNumber = "1162"; // arbitrary unused port #
    string LocalHostUrl = string.Format("http://localhost:{0}", PortNumber);
    string PhysicalPath = Environment.CurrentDirectory //  the path of compiled web app
    string VirtualPath = "";
    string RootUrl = LocalHostUrl + VirtualPath;			     
    
    // create a new process to start the ASP.NET Development Server
    Process process = new Process();
    
    /// configure the web server
    process.StartInfo.FileName = HttpRuntime.ClrInstallDirectory + "WebDev.WebServer.exe";
    process.StartInfo.Arguments = string.Format("/port:{0} /path:\"{1}\" /virtual:\"{2}\"", PortNumber, PhysicalPath, VirtualPath);
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.UseShellExecute = false;
    
    // start the web server
    process.Start();
    
    // rest of code...
