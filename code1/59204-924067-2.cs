        Response.Clear();
        // no buffering - allows large zip files to download as theyare zipped
        Response.BufferOutput = false;
        String ReadmeText= "Dynamic content for a readme file...\n" + 
                           DateTime.Now.ToString("G");
        string archiveName= String.Format("archive-{0}.zip", 
                                          DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
        using (ZipFile zip = new ZipFile())
        {
            // add a file entry into the zip, using content from a string
            zip.AddFileFromString("Readme.txt", "", ReadmeText);
            // add the set of files to the zip
            zip.AddFiles(filesToInclude, "files");
            // compress and write the output to OutputStream
            zip.Save(Response.OutputStream);
        }
        // Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
