    private Response<LookupResponseData> GetKeyIdBundleForLookup(
      string lookupId, int? key, string id)
    {
      if (!key.HasValue && string.IsNullOrEmpty(id))
        return new Error 
        { 
          Code = ErrorCodes.InvalidQueryParameter, 
          Message = "Either key or id must be specified" 
        };
      try
      {
        this.LookupService.GetKeyIdDescription(this.AccountId, 
          lookupId, 
          key, 
          id, 
          out var keyResult, 
          out var idResult, 
          out var description);
        if (!keyResult.HasValue)
          return new Error 
          {
            Code = ErrorCodes.InvalidOrMissingRecord, 
            Message = "No record found for parameters specified" 
          };
        return new LookupResponseData 
        { 
          Key = keyResult.Value, 
          Id = idResult, Description = description 
        };
            
      catch (Exception ex)
      {
        this.LoggerService.Log(this.AccountId, ex);
        return new Error 
        { 
          Code = ErrorCodes.Unknown, 
          Message = "API Call failed, please contact support. Details logged." }
        };
      }
    }
