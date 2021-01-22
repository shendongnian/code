    using System.DirectoryServices.ActiveDirectory;
    
    bool isDomain = false;
    
    try
    {
        Domain.GetComputerDomain();
        isDomain = true;
    }
    catch (ActiveDirectoryObjectNotFoundException)
    {
    }
