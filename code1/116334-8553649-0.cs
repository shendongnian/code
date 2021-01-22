    public void SaveStockInfoToAnotherFile()
    {
        string sourcePath = @"C:\inetpub\wwwroot";
        string destinationPath = @"G:\ProjectBO\ForFutureAnalysis";
        string sourceFileName = "startingStock.xml";
        string destinationFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".xml"; // Don't mind this. I did this because I needed to name the copied files with respect to time.
        string sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);
        string destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);
                
        if (!System.IO.Directory.Exists(destinationPath))
           {
             System.IO.Directory.CreateDirectory(destinationPath);
           }
        System.IO.File.Copy(sourceFile, destinationFile, true);
    }
