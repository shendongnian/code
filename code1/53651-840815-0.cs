        Response.Clear();
 
        System.Web.HttpContext c= System.Web.HttpContext.Current;
        String ReadmeText= String.Format("README.TXT\n\nHello!\n\nThis is a zip file that was dynamically generated at {0}\nby an ASP.NET Page running on the machine named '{1}'.\nThe server type is: {2}\n", 
                                         System.DateTime.Now.ToString("G"),
                                         System.Environment.MachineName,
                                         c.Request.ServerVariables["SERVER_SOFTWARE"]
                                         );
        string archiveName= String.Format("archive-{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
  
        using (ZipFile zip = new ZipFile())
        {
            foreach (var f in filesToInclude)
            {
                zip.AddFile(f, "files");
            }
            zip.AddFileFromString("Readme.txt", "", ReadmeText);
            zip.Save(Response.OutputStream);
        }
        Response.End();
