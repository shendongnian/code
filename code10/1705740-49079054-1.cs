    internal ServiceThrottle(ServiceHostBase host)
    {
        if (!((host != null)))
        {
            Fx.Assert("ServiceThrottle.ServiceThrottle: (host != null)");
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("host");
        }
        this.host = host;
        this.MaxConcurrentCalls = ServiceThrottle.DefaultMaxConcurrentCallsCpuCount;
        this.MaxConcurrentSessions = ServiceThrottle.DefaultMaxConcurrentSessionsCpuCount;
        this.isActive = true;
    }
