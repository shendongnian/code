	public override bool AcceptDrop(NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation)
	{
		using (var pasteBoard = info.DraggingPasteboard)
		{
			if (pasteBoard.PasteboardItems.Length > 0)
			{
				var range = new NSRange(-1, 0);
				foreach (var item in pasteBoard.PasteboardItems)
				{
					if (item.Types.Contains(UTType.FileURL))
					{
						var finderNode = item.GetStringForType(UTType.FileURL);
                        // you have a file from macOS' finder, do something with it, assumable in a table view you would add a record/row....
      			        var url = NSUrl.FromString(finderNode);
                        // url has the file extension, filename, full path, etc...
                       Post a notification / Add a task to GCD / etc...
   					}
					item.Dispose();
				}
                return true;
			}
		}
		return false;
	}
