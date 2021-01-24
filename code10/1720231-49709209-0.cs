    // Get selected item
    var selectedItem = lstboxSites.SelectedItem;
    // If user has not selected anything...
    if (selectedItem == null)
    {
        // Do whatever in this situation
    }
    // Get full path
    var filePath = string.Format(@"./site/{0}", selectedItem ?? "");
    // If file doesn't exist...
    if (!File.Exists(filePath))
    {
        // Do whatever in this situation
    }
    StreamReader sr = new StreamReader(filePath);
    var line = sr.ReadLine();
    sr.close();
