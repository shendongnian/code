    private static bool TryGetLogonUserId(IGetClientUsername clientController, string sClientId, out int? logonUserId, GetUsername func)
    {
        string username;
        if (func.Invoke(sClientId, out username))
        {
           // ... snip common code ...
        }
        return false;
    }
