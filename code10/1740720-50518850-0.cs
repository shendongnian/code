    private void InternalSend(FolderId parentFolderId, MessageDisposition messageDisposition)
    {
    	this.ThrowIfThisIsAttachment();
    
    	if (this.IsNew)
    	{
    		if ((this.Attachments.Count == 0) || (messageDisposition == MessageDisposition.SaveOnly))
    		{
    			this.InternalCreate(
    				parentFolderId,
    				messageDisposition,
    				null);
    		}
    		else
    		{
    			// If the message has attachments, save as a draft (and add attachments) before sending.
    			this.InternalCreate(
    				null,                           // null means use the Drafts folder in the mailbox of the authenticated user.
    				MessageDisposition.SaveOnly,
    				null);
    
    			this.Service.SendItem(this, parentFolderId);
    		}
    	}
    	...
