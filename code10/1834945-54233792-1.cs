    using Microsoft.TeamFoundation.Client;
    using Microsoft.VisualStudio.Services.Common;
    using System;
    using System.Net;   
    
    namespace TFSConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkCredential networkCredentials = new NetworkCredential(@"Domain\Account", @"Password");
                Microsoft.VisualStudio.Services.Common.WindowsCredential windowsCredentials = new Microsoft.VisualStudio.Services.Common.WindowsCredential(networkCredentials);
                VssCredentials basicCredentials = new VssCredentials(windowsCredentials);
                TfsTeamProjectCollection tfsColl = new TfsTeamProjectCollection(
                    new Uri("http://XXX:8080/tfs/DefaultCollection"),
                    basicCredentials);
                tfsColl.Authenticate(); // make sure it is authenticate
            }
        }
    }
