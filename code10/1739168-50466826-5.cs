    public ISiteSession CreateSiteSession(CustomerDetails customerDetails) {
        //...
        
        return new SiteSession(customer.Username, customer.CustomerRef, ePermitService);
    }
