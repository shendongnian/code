    ServiceSecurityContext ssc = ServiceSecurityContext.Current;
    
    if (!ssc.IsAnonymous && ssc.PrimaryIdentity != null)
    {
        string userName = ServiceSecurityContext.Current.PrimaryIdentity.Name;
    }
