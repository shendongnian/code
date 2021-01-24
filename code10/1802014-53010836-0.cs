    using System.Diagnostics;
    ...
    Process process = new Process();
    // Configure the process using the StartInfo properties.
    process.StartInfo.FileName = "chrome";
    process.StartInfo.Arguments = "-incognito www.somesite.com";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    process.Start();
    
    BrowserFactory.Attach(new BrowserDescription
    {
        Url = "www.somesite.com"
    });
    ...
