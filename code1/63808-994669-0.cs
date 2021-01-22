    string whoisLoggedIn(string HostOrIP)
    {
    System.Management.ConnectionOption­ s myConnectionOptions = new System.Management.ConnectionOptions();­
    myConnectionOptions.Impersonation ­ = System.Management.ImpersonationLev­ el.Impersonate;
    
    System.Management.ManagementScope ­ objwmiservice;
    System.Management.ManagementObject­ Searcher myObjectSearcher;
    System.Management.ManagementObject­ Collection myCollection;
    
    try
    {
    objwmiservice = new System.Management.ManagementScope(­ ("\\\\" + (HostOrIP + "\\root\\cimv2")), myConnectionOptions);
    objwmiservice.Connect();
    myObjectSearcher = new System.Management.ManagementObject­ Searcher(objwmiservice.Path.ToStri­ ng(), "Select UserName from Win32_ComputerSystem");
    myObjectSearcher.Options.Timeout = new TimeSpan(0, 0, 0, 0, 7000);
    myCollection = myObjectSearcher.Get();
    
    foreach (System.Management.ManagementObjec­ t myObject in myCollection)
    {
    if (!(myObject.GetPropertyValue("User­ name") == null))
    {
    string Userx = myObject.GetPropertyValue("Usernam­ e").ToString();
    int posx = Userx.LastIndexOf("\\");
    if ((posx > 0))
    {
    Userx = Userx.Substring((posx + 1));
    return Userx.ToUpper();
    }
    }
    }
    return "<Nobody>";
    }
    catch (Exception)
    {
    return "<Nobody>";
    }
    }
