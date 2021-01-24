    public Task<string> GetMxRecordForDomainAsync(string domain)
    {
    	return ExtractForDomainAsync(domain,  new MxRecordExtractor());
    }
    
    public Task<string> GetVerificationRecordForDomainAsync(string domain)
    {
    	return ExtractForDomainAsync(domain, new VerificationRecordExtractor());
    }
