        string leaseId = await LockingEntity(blockBlob);
        if (string.IsNullOrEmpty(leaseId) == false)
        {
           try
           {
              string esp = await blockBlob.DownloadTextAsync(Encoding.UTF8, AccessCondition.GenerateLeaseCondition(leaseId), null, null);
              state = JsonConvert.DeserializeObject<State>(esp);
              // …
           }
           finally
           {
              await blockBlob.ReleaseLeaseAsync(AccessCondition.GenerateLeaseCondition(leaseId));
           }
        }
           
 
