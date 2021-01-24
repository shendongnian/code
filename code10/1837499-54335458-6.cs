    private async Task<string> ExtractForDomainAsync(string domain, IExtractor extractor)
    {
    	try
    	{
    		var records = (await _graphClient.Domains[domain].VerificationDnsRecords.Request().GetAsync());
    		string extractedValue = String.Empty;
    
    		foreach (var record in records)
    		{
    			if (record.RecordType == extractor.RecordType)
    			{
    				extractedValue = extractor.GetValue(record);
    				break;
    			}
    		}
    
    		if (String.IsNullOrWhiteSpace(extractedValue))
    			throw new DomainRecordNotFoundException(extractor.ErrorMessage);
    
    		return extractedValue;
    	}
    	catch (ServiceException graphEx)
    	{
    		if (graphEx.StatusCode == System.Net.HttpStatusCode.NotFound)
    		{
    			throw new DomainNotFoundException();
    		}
    
    		throw new UnknownException(graphEx.StatusCode, graphEx.Error.Message);
    	}
    }
