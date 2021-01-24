    static void Main(string[] args)
    {
        // 14 is the identifier of the Remote Desktop Services role.
        HasServerFeatureById(14);
    }
    
    static bool HasServerFeatureById(UInt32 roleId)
    {
        try
        {
            ManagementClass serviceClass = new ManagementClass("Win32_ServerFeature");
            foreach (ManagementObject feature in serviceClass.GetInstances())
            {
                if ((UInt32)feature["ID"] == roleId)
                {
                    return true;
                }
            }
    
            return false;
        }
        catch (ManagementException)
        {
            // The most likely cause of this is that this is being called from an 
            // operating system that is not a server operating system.
        }
    
        return false;
    }
