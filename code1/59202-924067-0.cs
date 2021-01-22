        Response.Clear();
        String ReadmeText= String.Format("README.TXT\n\nHello!\n\nThis zip file was dynamically generated at {0}", 
                                         System.DateTime.Now.ToString("G"));
        string archiveName= String.Format("archive-{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
  
        using (ZipFile zip = new ZipFile())
        {
            zip.AddFileFromString("Readme.txt", "", ReadmeText);
            zip.AddFiles(filesToInclude, "files");
            zip.Save(Response.OutputStream);
        }
        Response.End();
