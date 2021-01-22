    try
    {
        if (folderItem.ModifyDate.Year != 1899)
        {
            this.FileModifiedDate = folderItem.ModifyDate.ToShortDateString() + 
                " " +
                folderItem.ModifyDate.ToLongTimeString();
        }
    }
    //we need this because it throws an exception if it's an invalid date...
    catch (ArgumentException) { } 
