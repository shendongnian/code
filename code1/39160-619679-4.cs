        Response.Clear();
        Response.BufferOutput = false;
        String ReadmeText= "This is content that will appear in a file " + 
                           "called Readme.txt.\n" + 
                           System.DateTime.Now.ToString("G") ; 
        string archiveName= String.Format("archive-{0}.zip", 
                                          DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "attachment; filename=" + archiveName);
  
        using (ZipFile zip = new ZipFile())
        {
            // add an entry from a string: 
            zip.AddEntry("Readme.txt", "", ReadmeText);
            zip.AddFiles(filesToInclude, "files");
            zip.Save(Response.OutputStream);
        }
        // Response.End();  // no - see http://stackoverflow.com/questions/1087777
        HttpContext.Current.ApplicationInstance.CompleteRequest();
