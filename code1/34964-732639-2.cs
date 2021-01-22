    using Cassia;
    public static bool IsSomeoneLoggedOn(string server)
    {
        foreach (ITerminalServicesSession session in new TerminalServicesManager().GetSessions(server))
        {
            if (!string.IsNullOrEmpty(session.UserName))
            {
                return true;
            }
        }
        return false;
    }
