                String UserName = "username@om";
            String Password = "dd@#";
            System.Security.SecureString secureString = new System.Security.SecureString();
            foreach (char c in Password)
                secureString.AppendChar(c);
            PSCredential credential = new PSCredential(UserName, secureString);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("https://outlook.office365.com/powershell"), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credential);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            connectionInfo.SkipCACheck = true;
            connectionInfo.SkipCNCheck = true;
            connectionInfo.MaximumConnectionRedirectionCount = 4;
            Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            // Make a Get-Mailbox requst using the Server Argument
            Command gmGetMailbox = new Command("Get-MailboxAutoReplyConfiguration");
            gmGetMailbox.Parameters.Add("Identity", "jcool@datarumble.com");
            Pipeline plPileLine = runspace.CreatePipeline();
            plPileLine.Commands.Add(gmGetMailbox);
            Collection<PSObject> RsResultsresults = plPileLine.Invoke();
            foreach (PSObject obj in RsResultsresults)
            {
                Console.WriteLine(obj.Members["AutoReplyState"].Value.ToString());
            }
            plPileLine.Stop();
            plPileLine.Dispose();
