	public void ProvideDataForType(NSPasteboard pasteboard, NSPasteboardItem item, string type)
	{
		if (type == UTType.FileURL )
		{
			var url = new NSUrl("/Users/Sushi/Desktop/StackOverflow.png", false);
			url.WriteToPasteboard(pasteboard);
		}
	}
