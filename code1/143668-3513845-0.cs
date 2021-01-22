    ObjectFactory.Initialize(x =>
    {
		x.PullConfigurationFromAppConfig = true;
		x.SetAllProperties(p => p.TypeMatches(t => 
            t.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0));
    }		
