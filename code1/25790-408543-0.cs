    enum FlowType
    {
        Laminar
        , Transient
        , Turbulent
    };
    staic string Reynolds(int d, int v, int rho, int mu)
    {
        int n = (d*v*rho) / mu;
        
        if(n < 2000)
        {
            return FlowType.Laminar;
        }
        else if(n >= 2000 && n < 4000)
        {
            return FlowType.Transient;
        }
        else
        {
            return FlowType.Turbulent;
        }
    }
