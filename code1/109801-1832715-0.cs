    using System.IO;
    using System.Web.Hosting;
***
    
    using (StreamReader sr = new StreamReader(VirtualPathProvider.OpenFile("~/foo.txt")))
    {
        string content = sr.ReadToEnd();
    }
