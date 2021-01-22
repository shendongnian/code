    var messageList = ...;
    // Restrict your list to certain criteria
    var customMessageList = messageList.FindAll(m => m.UserId == someId);
    
    if (customMessageList != null && customMessageList.Count > 0)
    {
    	// Create list with positions in origin list
    	List<int> positionList = new List<int>();
    	foreach (var message in customMessageList)
    	{
    		var position = messageList.FindIndex(m => m.MessageId == message.MessageId);
    		if (position != -1)
    			positionList.Add(position);
    	}
    	// To be able to remove the items in the origin list, we do it backwards
        // so that the order of indices stays the same
    	positionList = positionList.OrderByDescending(p => p).ToList();
    	foreach (var position in positionList)
    	{
    		messageList.RemoveAt(position);
    	}
    }
