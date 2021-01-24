    public IActionResult Export()
    {
        MemoryStream content = new MemoryStream(); // Gets disposed by FileStreamResult.        
        using (ExcelPackage package = new ExcelPackage(content))
        {
            // Code to create the content goes here.
        
            package.Save();
        }
            
        content.Position = 0;
            
        return new FileStreamResult(content, "application/octet-stream") { 
            FileDownloadName = "test.xlsx"
            };            
    }  
