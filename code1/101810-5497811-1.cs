    using NetFwTypeLib; 
    // (don't forget to add it to your references, its under the COM tab)
    private static INetFwPolicy2 getCurrPolicy()
    {
        INetFwPolicy2 fwPolicy2;
        Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
        return fwPolicy2;
    }
    public bool getFirewallStatus()
    {
        INetFwPolicy2 fwPolicy2 = getCurrPolicy();
        NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes;
        //read Current Profile Types (only to increase Performace)
        //avoids access on CurrentProfileTypes from each Property
        fwCurrentProfileTypes = (NET_FW_PROFILE_TYPE2_)fwPolicy2.CurrentProfileTypes;
        return (fwPolicy2.get_FirewallEnabled(fwCurrentProfileTypes));
    }
    public void setFirewallStatus(bool newStatus)
    {
        NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes;
        INetFwPolicy2 currPolicy = getCurrPolicy();
        //read Current Profile Types (only to increase Performace)
        //avoids access on CurrentProfileTypes from each Property
        fwCurrentProfileTypes = (NET_FW_PROFILE_TYPE2_)currPolicy.CurrentProfileTypes;
        currPolicy.set_FirewallEnabled(fwCurrentProfileTypes, newStatus);
    }
