    var colorItemText = "Colour";
    var colorMenuItem = ctmFile.Items.Cast<ToolStripMenuItem>()
                          .FirstOrDefault(mi => mi.Text == colorItemText);
    if (lvFiles.FocusedItem.ImageKey.ToString() == "Folder")
    {
        //  Create and add if not already present
        if (colorMenuItem == null)
        {
            colorMenuItem = new ToolStripMenuItem(colorItemText);
            ctmFile.Items.Add(colorMenuItem);
        }
    }
    else if (colorMenuItem != null)
    {
        //  Remove if already present. 
        ctmFile.Items.Remove(colorMenuItem);
    }
