        Response.Clear();
        Response.BufferOutput = false;
        System.Web.HttpContext c= System.Web.HttpContext.Current;
        String ReadmeText= "This is content that will appear in a file " + 
                           "called Readme.txt.\n" + 
                           System.DateTime.Now.ToString("G") ; 
        string archiveName= String.Format("archive-{0}.zip", 
                                          DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
  
        using (ZipFile zip = new ZipFile())
        {
            // add an entry from a string: 
            zip.AddEntry("Readme.txt", "", ReadmeText);
            zip.AddFiles(f, "files");
            zip.Save(Response.OutputStream);
        }
        // Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
