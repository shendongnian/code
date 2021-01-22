    public static void RunService()
    {
            Type t = typeof(Child);
            ServiceHost svcHost = new ServiceHost(t, new Uri("http://localhost:8001/People"));
            svcHost.AddServiceEndpoint(typeof(IWcfClass), new BasicHttpBinding(), "Basic");
            svcHost.Open();
    }
