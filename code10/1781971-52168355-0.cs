       using Cassia;
        // call all process from sessions
        private void GetSessionsProcess()
        {
            ITerminalServicesManager manager = new TerminalServicesManager();
            ITerminalServer server = manager.GetLocalServer(); // server name
            server.Open();
            WriteProcesses(server.GetProcesses(), manager);
        }
        // get all process that is running in all sessions
        private void WriteProcesses(IEnumerable<ITerminalServicesProcess> processes, ITerminalServicesManager manager)
        {
            ITerminalServer server = manager.GetLocalServer();
            foreach (ITerminalServicesProcess process in processes)
            {
                foreach (ITerminalServicesSession session in server.GetSessions())
                {
                    if (process.ProcessName == "notepad.exe" && session.SessionId == process.SessionId)
                    {
                        PopulateTerminalsList(process.SessionId.ToString(), process.ProcessId.ToString(), process.ProcessName, session.UserAccount.ToString(), session.UserName);
                    }
                }
            }
        }
