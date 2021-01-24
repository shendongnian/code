    string ComputerName = "SomeComputer";
    string UserID = "SomeUser";
    string Domain = "SomeDomain";
    string Passwd = "SomePasswd";
            
    WSManHelper WSMH = new WSManHelper(ComputerName, 
    Microsoft.Management.Infrastructure.Options.PasswordAuthenticationMechanism.Kerberos, Domain, UserID, Passwd);
    if (WSMH.Connected)
    {
         WSMH.GetWMIDataFromSystem();
         WSMH.EnumerateBaseSoftwareKeys();
         // check out the data 
         foreach (string DisplayName in WSMH.RegSoftwareUninstall)
         {
              Console.WriteLine(DisplayName);
         }
    }
