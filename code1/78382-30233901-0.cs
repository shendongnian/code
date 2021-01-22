     public static byte[] PackageDocsAsZip(byte[] fileBytesTobeZipped, string packageFileName)
    {
        try
        {
            string parentSourceLoc2Zip = @"C:\\\\UploadedDocs"\SG-ACA OCI Packages";
            if (Directory.Exists(parentSourceLoc2Zip) == false)
            {
                Directory.CreateDirectory(parentSourceLoc2Zip);
            }
            //if destination folder already exists then delete it
            string sourceLoc2Zip = string.Format(@"{0}\{1}", parentSourceLoc2Zip, packageFileName);
            if (Directory.Exists(sourceLoc2Zip) == true)
            {
                Directory.Delete(sourceLoc2Zip, true);
            }
            Directory.CreateDirectory(sourceLoc2Zip);
      
                 FilePath = string.Format(@"{0}\{1}",
                        sourceLoc2Zip,
                        "filename.extension");//e-g report.xlsx , report.docx according to exported file
                 File.WriteAllBytes(FilePath, fileBytesTobeZipped);
            //if zip already exists then delete it
            if (File.Exists(sourceLoc2Zip + ".zip"))
            {
                File.Delete(sourceLoc2Zip + ".zip");
            }
            //now zip the source location
            ZipFile.CreateFromDirectory(sourceLoc2Zip, sourceLoc2Zip + ".zip", System.IO.Compression.CompressionLevel.Optimal, true);
            return File.ReadAllBytes(sourceLoc2Zip + ".zip");
        }
        catch
        {
            throw;
        }
    }
