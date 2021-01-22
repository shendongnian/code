    using Cassia;
    foreach (ITerminalServicesSession session in new TerminalServicesManager().GetSessions())
    {
        if (!string.IsNullOrEmpty(session.UserName))
        {
            Console.WriteLine("Session {0} (User {1})", session.SessionId, session.UserName);
        }
    }
