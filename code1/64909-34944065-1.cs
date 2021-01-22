    public SYSTEM_POWER_CAPABILITIES getSystemPowerCapabilites(){
    {
        SYSTEM_POWER_CAPABILITIES systemPowerCapabilites;
        GetPwrCapabilities(out systemPowerCapabilites);
        return systemPowerCapabilites;
    }
    getSystemPowerCapabilites().LidPresent;
