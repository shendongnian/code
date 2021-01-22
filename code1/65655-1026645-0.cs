    private static bool TryGetLogonUserIdByUsername(IGetClientUsername clientController, string sClientId, out int? logonUserId, bool graphical)
    {
        string username;
        bool gotClient = false;
        if (graphical)
        {
            gotClient = clientController.GetClientGraphicalUsername(sClientId, out username);
        }
        else
        {
            gotClient = clientController.GetClientUsername(sClientId, out username);
        }
        if (gotClient)
        {
                   // ... snip common code ...
        }
        return false;
    }
