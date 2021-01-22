    m_SvcHost = new MySvcHost(this);
            
            if (Config.ServiceEndpoint != null && Config.ServiceEndpoint != String.Empty)
            {
                //m_SvcHost.Description.Endpoints.Clear();
                
                m_SvcHost.AddServiceEndpoint(typeof(IMobileMonitoringSvc),
                    new BasicHttpBinding(),
                    Config.ServiceEndpoint);
            }
            
            // open the svchost and allow incoming connections
            m_SvcHost.Open();
    
