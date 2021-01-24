    public override void MouseDown(NSEvent theEvent)
    {
    	var pasteboardItem = new NSPasteboardItem();
    	pasteboardItem.SetDataProviderForTypes(this, new string[1] { UTType.FileURL });
    
    	var draggingItem = new NSDraggingItem(pasteboardItem);
    	var fileDragIcon = new NSImage("theDraggingIcon.png");
    	draggingItem.SetDraggingFrame(new CoreGraphics.CGRect(0,0,40,40), fileDragIcon);
    	BeginDraggingSession(new NSDraggingItem[1] { draggingItem }, theEvent, this);
    }
