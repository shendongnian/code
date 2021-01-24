    public Result Execute(
      ExternalCommandData commandData, 
      ref string message, 
      ElementSet elements)
    {
    	UIApplication application = commandData.Application;
    	Document mainDocument = application.ActiveUIDocument.Document;
    
    	if(elements.Size > 0)
    	{
    		//Only 1 room should be selected
    		return Result.Failed;
    	}
    
    	Room room = null;
    
    	foreach(Element element in elements)
    	{
    		room = element as Room;
    	}
    
    	if(room == null)
    	{
    		//A non-room element was selected
    		return Result.Failed;
    	}
    
    	GetRoomDimensions(mainDocument, room);
    	
    	return Result.Success
    }
