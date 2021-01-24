	ToolStripMenuItem Colour = new ToolStripMenuItem("Colour");
	Colour.Name= "Colour"; //Add a name (key) to your menu.
	ctmFile.Show(Cursor.Position);
	Selecteditem = lvFiles.FocusedItem.Text.ToString();
	if (lvFiles.FocusedItem.ImageKey.ToString() == "Folder")
	{
		if (!ctmFile.Items.ContainsKey(Colour.Name)) //Look for the key
		{
			ctmFile.Items.Add(Colour);
		}
	}
	else
	{
		if (ctmFile.Items.ContainsKey(Colour.Name)) //Look for the key
		{
			ctmFile.Items.Remove(Colour);
		}
	}
