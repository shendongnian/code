        SecureString password = new SecureString();
        string str_password = "pass";
        string username = "userr";
        string liveIdconnectionUri = "http://exchange.wenatex.com/Powershell?serializationLevel=Full";
        
        foreach (char x in str_password)
        {
            password.AppendChar(x);
        }
        
        PSCredential credential = new PSCredential(username, password);
        // Set the connection Info
        WSManConnectionInfo connectionInfo = new WSManConnectionInfo((new Uri(liveIdconnectionUri)), "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
        credential);
        connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
        // create a runspace on a remote path
        // the returned instance must be of type RemoteRunspace
        Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
        
        PowerShell powershell = PowerShell.Create();
        PSCommand command = new PSCommand();
        
        command.AddCommand("Enable-Mailbox");
        command.AddParameter("Identity", usercommonname);
        command.AddParameter("Alias", userlogonname);
        command.AddParameter("Database", "MBX_SBG_01");
        
        
        powershell.Commands = command;
        try
        {
            // open the remote runspace
            runspace.Open();
            // associate the runspace with powershell
            powershell.Runspace = runspace;
            // invoke the powershell to obtain the results
            return = powershell.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // dispose the runspace and enable garbage collection
            runspace.Dispose();
            runspace = null;
            // Finally dispose the powershell and set all variables to null to free
            // up any resources.
            powershell.Dispose();
            powershell = null;
        }
