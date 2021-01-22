    ManualResetEvent m_svcMRE = new ManualResetEvent(false);
    MyServiceClient m_svcProxy = new MyServiceClient(binding, address);
    m_svcProxy.DoSomethingCompleted += (sender, args) => {  m_svcMRE.Set(); };
    public void DoSomething()
    {
        m_svcMRE.Reset();
        m_svcProxy.DoSomething();
        m_svcMRE.WaitOne();
    }
