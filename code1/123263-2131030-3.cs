        public Omicron(int deviceID)
        {
            try
            {
                if (g_Omicron == null)
                    g_Omicron = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<CMEngineWrapper.IOmicronDll>();
                m_UniqueIdentifier = Guid.NewGuid();
                m_Logger = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<AdvAdmittance.Framework.ILogger>();
                m_ID = deviceID;
                GetConfiguration();
                g_InstancesCount++;
                m_PollThread = new Thread(new ThreadStart(DoPoll));
                m_PollThread.Start();
            }
