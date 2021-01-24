	ctmFile.Show(Cursor.Position);
	Selecteditem = lvFiles.FocusedItem.Text.ToString();
	if (lvFiles.FocusedItem.ImageKey.ToString() == "Folder")
	{
		if (!ctmFile.Items.ContainsKey("Colour")) 
		{
	        ToolStripMenuItem Colour = new ToolStripMenuItem("Colour");
	        Colour.Name= "Colour"; //Add a name (key) to your menu.
			ctmFile.Items.Add(Colour);
		}
	}
	else
	{
		if (ctmFile.Items.ContainsKey("Colour")) 
		{
			ctmFile.Items.RemoveByKey("Colour");
		}
	}
