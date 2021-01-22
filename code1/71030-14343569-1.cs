    // Get recycle folder
    Folder Recycler = Shl.NameSpace(10);
    FolderItems items = Recycler.Items();
    for (int i = 0; i < items.Count; i++)
    {
        try
        {
            FolderItem FI = items.Item(i);
            string FileName = Recycler.GetDetailsOf(FI, 0);
            string FilePath = Recycler.GetDetailsOf(FI, 1);
            string RecyleDate = Recycler.GetDetailsOf(FI, 2);
            if (FileName == "your file/folder")
            {
                // check if chosen item is a folder
                if (FI.IsFolder)
                {
                    Directory.Delete(FI.Path, true);
                }
                else
                {
                    File.Delete(FI.Path);
                }
            }
        }
        catch (Exception exc)
        {
            ...
        }
