    if (oDirectory.Exists)
    {
        //Loop files
        foreach (FileInfo oFile in oDirectory.GetFiles())
        {
            using (FileStream oStream = new FileStream(oFile.FullName, FileMode.Open))
            {
                //Check if file is a zip file
                if (C1ZipFile.IsZipFile(oStream))
                {
                // ...
                }
            }
            //Delete the file
            oFile.Delete();
        }
    }    
