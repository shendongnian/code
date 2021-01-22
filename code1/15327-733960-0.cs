    using Cassia;
    foreach (ITerminalServicesSession session in new TerminalServicesManager().GetSessions())
    {
        if ((session.CurrentTime - session.LastInputTime > TimeSpan.FromMinutes(10)) &&
            (!string.IsNullOrEmpty(session.UserName)))
        {
            Console.WriteLine("Session {0} (User {1}) is idle", session.SessionId, session.UserName);
        }
    }
