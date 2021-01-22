        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Net;
        using System.Net.Sockets;
        using System.DirectoryServices.AccountManagement;
        using System.DirectoryServices.ActiveDirectory;
    public doIt()
            {
                DirectoryContext mycontext = new DirectoryContext(DirectoryContextType.Domain,"project.local");
                DomainController dc = DomainController.FindOne(mycontext);
                IPAddress DCIPAdress = IPAddress.Parse(dc.IPAddress);
            }
