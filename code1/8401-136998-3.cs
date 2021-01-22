	public bool IsEventHandlerRegistered(Delegate prospectiveHandler)
	{   
		if ( this.EventHandler != null )
		{
			foreach ( Delegate existingHandler in this.EventHandler.GetInvocationList() )
			{
				if ( existingHandler == prospectiveHandler )
				{
					return true;
				}
			}
		}
		return false;
	}
