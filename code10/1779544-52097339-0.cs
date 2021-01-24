    WSManConnectionInfo wmc = new WSManConnectionInfo(new Uri(`"http://xxx/powershell`"));
    wmc.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    wmc.ShellUri = `"http://schemas.microsoft.com/powershell/Microsoft.Exchange`";
    using (Runspace runspace = RunspaceFactory.CreateRunspace(wmc))
    {
    }
