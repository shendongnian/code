	private void OriginalDrop_LstBox_DragEnter(object sender, DragEventArgs e)
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
	{
		var files = (string[])e.Data.GetData(DataFormats.FileDrop);
		if (files.Length == 1 && OriginalDrop.Items.Count == 0)
		{
			e.Effect = DragDropEffects.All;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}
