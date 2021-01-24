    private string[] GetListOfDocumentLink()
    {
       string path = string.Empty;
       string constantPath = "\\\\A\\B\\C\\D\\";
       string folderName = string.Empty;
       string year = string.Empty;
       // determine folderName and year.  
       path = constantPath
            + Path.DirectorySeparatorChar.ToString()
            + folderName
            + Path.DirectorySeparatorChar.ToString()
            + year;
            var filter = Berichtsnummer + "*.pdf";
            string[] allFiles = Directory.GetFiles(path, filter);
            return allFiles;
    }
