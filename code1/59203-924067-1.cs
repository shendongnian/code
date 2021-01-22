        Response.Clear();
        String ReadmeText= String.Format("Dynamic content for a readme file...");
        string archiveName= String.Format("archive-{0}.zip", 
                                          DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
        using (ZipFile zip = new ZipFile())
        {
            zip.AddFileFromString("Readme.txt", "", ReadmeText);
            zip.AddFiles(filesToInclude, "files");
            zip.Save(Response.OutputStream);
        }
        Response.End();
