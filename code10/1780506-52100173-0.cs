       var target = _container.GetBlockBlobReference(targetItemName);
       // StartCopy will add a request to a queue, that's all
       target.StartCopy(source);
                
       // Now we poll the copy's status
       while (target.CopyState.Status == CopyStatus.Pending)
            await Task.Delay(500);
    
       if (target.CopyState.Status != CopyStatus.Success)
            throw new ApplicationException("Copy failed: " + target.CopyState.Status);
