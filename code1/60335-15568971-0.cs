    public static string GetDomainNameUserNameFromUPN(string strUPN)
    {
        try
        {
            WindowsIdentity wi = new WindowsIdentity(strUPN);
            WindowsPrincipal wp = new WindowsPrincipal(wi);
           
           return wp.Identity.Name;
            
        }
        catch (Exception ex)
        {
        }
        return "";
    }
