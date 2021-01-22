using NetFwTypeLib; 
// (don't forget to add it to your references, its under the COM tab)
    
public bool isWinXP()
{
   OperatingSystem os = Environment.OSVersion;
   int majorVersion = os.Version.Major;
   // see http://msdn.microsoft.com/en-us/library/ms724832(v=vs.85).aspx
   if (majorVersion &lt 6) // if O/S is not Vista or Windows7
   {
       return true;
   }
   else
   {
       return false;
   }
}
private static INetFwPolicy2 getCurrPolicy()
{
    INetFwPolicy2 fwPolicy2;
    Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
    fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
    return fwPolicy2;
}
public bool getFirewallStatus()
{
    bool result = false;
    switch (isWinXP())
    {
        case true:
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false); 
            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
            result = mgr.LocalPolicy.CurrentProfile.FirewallEnabled;
            break;
        case false:
            INetFwPolicy2 fwPolicy2 = getCurrPolicy();
            NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes;
            //read Current Profile Types (only to increase Performace)
            //avoids access on CurrentProfileTypes from each Property
            fwCurrentProfileTypes = (NET_FW_PROFILE_TYPE2_)fwPolicy2.CurrentProfileTypes;
            result = (fwPolicy2.get_FirewallEnabled(fwCurrentProfileTypes));
            break;
        default:
            result = false; // assume Win7 by default
            break;
    }
    return result;
}
public void setFirewallStatus(bool newStatus)
{
    switch (isWinXP())
    {
        case true:
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
            mgr.LocalPolicy.CurrentProfile.FirewallEnabled = newStatus;
            break;
        case false:
            NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes;
            INetFwPolicy2 currPolicy = getCurrPolicy();
            //read Current Profile Types (only to increase Performace)
            //avoids access on CurrentProfileTypes from each Property
            fwCurrentProfileTypes = (NET_FW_PROFILE_TYPE2_)currPolicy.CurrentProfileTypes;
            currPolicy.set_FirewallEnabled(fwCurrentProfileTypes, newStatus);
            break;
        default:
            NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes1;
            INetFwPolicy2 currPolicy1 = getCurrPolicy();
            //read Current Profile Types (only to increase Performace)
            //avoids access on CurrentProfileTypes from each Property
            fwCurrentProfileTypes1 = (NET_FW_PROFILE_TYPE2_)currPolicy1.CurrentProfileTypes;
            currPolicy1.set_FirewallEnabled(fwCurrentProfileTypes1, newStatus);
            break;
    }
}
