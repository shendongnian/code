    // Returns a list of customers still using the PositionProvider
    CustomerProvider.Instance.GetList(); 
    
    // Returns my specific customer data
    CustomerProvider.Instance.GetCustomersByUserPermission();
    
    // Returns a list of sites still using the PositionProvider
    SiteProvider.Instance.GetList(); 
    
    // Not part of the SiteProvider!
    SiteProvider.Instance.GetCustomersByUserPermission(); 
