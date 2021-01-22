    // Loop through the checked items, same as you did.
    foreach (var checkedItem in this.organizeFav.CheckedItems)
    {
        // Cast from IEnumerable to IEnumerable<T> so we can abuse LINQ
        var matches = favoritesToolStripMenuItem.DropDownItems.Cast<ToolStripItem>()
                      // Only items that the Text match
                      .Where(item => item.Text == checkedItem.Text)
                      // Don't match separators
                      .Where(item => item is ToolStripMenuItem)
                      // Select the keys for the later .Remove call
                      .Select(item => item.Name);
        // Loop through all matches        
        foreach (var key in matches)
        {
            // Remove them with the Remove(string key) overload.
            favoritesToolStripMenuItem.Remove(key);
        }
    }
