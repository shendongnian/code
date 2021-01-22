    ServiceHost host = ...;
    var col = new ReadOnlyCollection<IAuthorizationPolicy>(new IAuthorizationPolicy[] { new MyPolicy() });
    
    ServiceAuthorizationBehavior sa = host.Description.Find<ServiceAuthorizationBehavior>();
    if ( sa == null ) {
      sa = new ServiceAuthorizationBehavior();
      host.Description.Behaviors.Add(sa);
    }
    sa.ExternalAuthorizationPolicies = col;
