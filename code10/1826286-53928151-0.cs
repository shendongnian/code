    [HttpPost]
    public string DeleteOneItem(int id)
    {
        //query the database to check if there is image for this item.
        var currentItemToDelete = GetItemFromDBDateFormatted(id);
        if (!string.IsNullOrEmpty(currentItemToDelete.FileName))
        {
            //delete the image from disk. 
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string fullImagePath = Path.Combine(contentRootPath + "\\Attachments", currentItemToDelete.FileName);
            if (System.IO.File.Exists(fullImagePath))
            {
                try
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(fullImagePath);
                }
                catch (Exception e) { }
            }
        }
        return "";
    }
