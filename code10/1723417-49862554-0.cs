    foreach (GridBatchEditingCommand command in e.Commands)
    {
    	Hashtable insValues = command.NewValues;
    
    	#region insert new
    
    	if (command.Type == GridBatchEditingCommandType.Insert)
    	{
    		string name = insValues["name"].ToString();
    	}
    
    	#endregion
    
    	#region update existing
    
    	if (command.Type == GridBatchEditingCommandType.Update)
    	{
    		string name = insValues["name"].ToString();
    	}
    
    	#endregion
    }
