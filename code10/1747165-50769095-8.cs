	public override NSDragOperation ValidateDrop(NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation)
	{
		var operation = NSDragOperation.Copy;
		using (var pasteBoard = info.DraggingPasteboard)
		{
			foreach (var item in pasteBoard.PasteboardItems)
			{
				if (!item.Types.Contains(UTType.FileURL))
				{
					operation = NSDragOperation.None;
				}
				item.Dispose();
			}
		}
		return operation;
	}
