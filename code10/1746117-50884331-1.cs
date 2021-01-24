    <pre>
    public IHttpActionResult GetBillingInformation(int clientId) 
    {
        var merchant = clientRepository.Get(clientId);
        if(!UserIsConfiguredToAccessMerchant(User, merchant))
            return Unauthorized();
    
    }
    </pre>  
