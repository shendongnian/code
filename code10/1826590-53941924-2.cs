    public async Task<IActionResult> ApproveEntity([FromBody] Entity[] entities)
    {
    	return await Task.Run<IActionResult>(() =>
    	{
    		try
    		{
    			//Do synchronisation if needed here.
    
    			try
    			{
    				try
    				{
    					if (this.ValidateConcurrencyForWriteBack(Entity))
    					{
    
    						return this.BadRequest("Concurrency Error : Somebody else has already done this action. Please refresh and try again.");
    					}
    					else
    					{
    						try
    						{
    							if (Entity.SupportingDocuments?.Count > 0)
    							{
    								this.UploadDocumentsToBlob(Entity, user);//Change method to be synchronous.
    								this.OneSoeUow.Commit();
    							}
    						}
    						catch (Exception ex)
    						{
    							throw;
    						}
    
    						this.BulkChallengeApproveReject(entities, user);//Change method to be synchronous.
    					}
    				}
    	}
    			catch (DbUpdateConcurrencyException ex)
    			{
    
    			}
    		}
    		catch (Exception ex)
    		{
    
    		}
    
    		return this.Ok(Entity)
    	});
    }
