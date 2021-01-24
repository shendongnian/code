    var colorMenuItem = ctmFile.Items.Cast<ToolStripMenuItem>()
                          .FirstOrDefault(mi => mi.Text == "Colour");
    if (lvFiles.FocusedItem.ImageKey.ToString() == "Folder")
    {
        //  Create and add if not already present
        if (colorMenuItem == null)
        {
            colorMenuItem = new ToolStripMenuItem("Colour");
            ctmFile.Items.Add(colorMenuItem);
        }
    }
    else if (colorMenuItem != null)
    {
        //  Remove if already present. 
        ctmFile.Items.Remove(colorMenuItem);
    }
