        Response.Clear();
        Response.BufferOutput = false; // false = stream immediately
        System.Web.HttpContext c= System.Web.HttpContext.Current;
        String ReadmeText= String.Format("README.TXT\n\nHello!\n\n" + 
                                         "This is text for a readme.");
        string archiveName= String.Format("archive-{0}.zip", 
                                          DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
  
        using (ZipFile zip = new ZipFile())
        {
            zip.AddFiles(f, "files");            
            zip.AddFileFromString("Readme.txt", "", ReadmeText);
            zip.Save(Response.OutputStream);
        }
        Response.Close();
