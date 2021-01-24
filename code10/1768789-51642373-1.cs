    if (e.Data.GetData(DataFormats.FileDrop, false) != null)
    {
        string[] DroppedDirectories = (string[]) e.Data.GetData(DataFormats.FileDrop,false);
        foreach(string directory in DroppedDirectories)
        {
            try
            {
                ListViewItem Dir = new ListViewItem(Path.GetFileNameWithoutExtension(directory));
                //Rest of code
            }
            catch(Exception ex)
            {
                LogList.Items.Add(DateTime.Now + ": Entry " + directory + " is not a directory");
            }
        }
    }
