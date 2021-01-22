    public static void ClearAllPools()
    {
        if (!OracleInit.bSetDllDirectoryInvoked)
        {
            OracleInit.Initialize();
        }
        if (((ConnectionDispenser.m_ConnectionPools == null) || (ConnectionDispenser.m_ConnectionPools.Count == 0)) && ((ConnectionDispenser.m_htSvcToRLB == null) || (ConnectionDispenser.m_htSvcToRLB.Count == 0)))
        {
            throw new InvalidOperationException();
        }
        ConnectionDispenser.ClearAllPools();
    }
    
     
