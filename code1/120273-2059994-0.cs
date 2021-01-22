    m_SvcHost = new ServiceHost(this);
    m_SvcHost.Description.Endpoints.Clear(); // <-- added
  
    if (Config.ServiceEndpoint != null && Config.ServiceEndpoint != String.Empty)
    {
        m_SvcHost.AddServiceEndpoint(typeof(IMyService),
            new BasicHttpBinding(),
            Config.ServiceEndpoint);
    }
    m_SvcHost.Open();
