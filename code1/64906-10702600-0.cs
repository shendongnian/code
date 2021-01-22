            IContexteRemotePowerShell crp:
            crp.ConfigurationName = "Microsoft.Exchange";
            crp.RemoteUri = "http://exhangeserver/powershell";
            crp.User = "account who has rights to do stuff on the exchange server";
            crp.Password = "its password";
            crp.Domaine = "Domain";
    private static void Connect(IContexteRemotePowerShell contexte)
        {
            try
            {
                Espace = RunspaceFactory.CreateRunspace();
                Espace.Open();
            }
            catch (InvalidRunspaceStateException ex)
            {
                throw new TechniqueException(MethodBase.GetCurrentMethod(), "Error while creating runspace.", ex);
            }
            // Create secure password
            SecureString password = new SecureString();
            foreach (char c in contexte.Password)
            {
                password.AppendChar(c);
            }
            // Create credential
            PSCredential psc = new PSCredential(contexte.User, password);
            PSCommand command = new PSCommand();
            command.AddCommand("New-PSSession");
            command.AddParameter("Credential", psc);
            if (!String.IsNullOrEmpty(contexte.Serveur))
                command.AddParameter("computername", contexte.Serveur);
            if (!String.IsNullOrEmpty(contexte.RemoteUri))
                command.AddParameter("ConnectionUri", new Uri(contexte.RemoteUri));
            if (!string.IsNullOrEmpty(contexte.ConfigurationName))
                command.AddParameter("ConfigurationName", contexte.ConfigurationName);
            //// Create the session
            PowerShell powershell = PowerShell.Create();
            powershell.Commands = command;
            powershell.Runspace = Espace;
            Collection<PSObject> result = ExecuterCommande(command);
            if (result.Count != 1)
                throw new TechniqueException(MethodBase.GetCurrentMethod(),
                                                "Error while connecting.");
            // Create session variable
            command = new PSCommand();
            command.AddCommand("Set-Variable");
            command.AddParameter("Name", "ra");
            command.AddParameter("Value", result[0]);
            ExecuterCommande(command);
        }
    private const string InvokeCommand = "Invoke-Command -ScriptBlock {{ {0} }} -Session $ra";
        private static string ExecuteRemoteScript(string cmd)
        {
            PSCommand command = new PSCommand();
            command.AddScript(string.Format(InvokeCommand, cmd));
            Collection<PSObject> result = ExecuterCommande(command);
            StringBuilder sb = new StringBuilder();
            foreach (PSObject obj in result)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().Trim();
        }
