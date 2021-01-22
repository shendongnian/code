    using System;
    using System.Security.Principal;
    using Cassia;
    namespace CassiaSample
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                ITerminalServicesManager manager = new TerminalServicesManager();
                using (ITerminalServer server = manager.GetRemoteServer("your-server-name"))
                {
                    server.Open();
                    foreach (ITerminalServicesSession session in server.GetSessions())
                    {
                        NTAccount account = session.UserAccount;
                        if (account != null)
                        {
                            Console.WriteLine(account);
                        }
                    }
                }
            }
        }
    }
