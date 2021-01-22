    private static readonly MethodInfo getRegularLogin = typeof(IGetClientUsername).GetMethod("GetClientUsername");
    private static bool TryGetLogonUserIdByUsername(IGetClientUsername clientController, string sClientId, out int? logonUserId)
    {
        
        string username;
        return TryGetLoginReflective(getRegularLogin, clientController, sClientId, out username, out logonUserId);
    }
    private static readonly MethodInfo getGraphicalLogin = typeof(IGetClientUsername).GetMethod("GetClientGraphicalUsername");
    private static bool TryGetLogonUserIdByGraphicalUsername(IGetClientUsername clientController, string sClientId, out int? logonUserId)
    {
        string username;
        return TryGetLoginReflective(getGraphicalLogin,  clientController, sClientId, out username, out logonUserId);
    }
    private static bool TryGetLoginReflective(MethodInfo method, IGetClientUsername clientController, string sClientId, out string username, out int? logonUserId)
    {
        object[] args = new object[]{sClientId, null};
        if((bool)method.Invoke(clientController, args))
        {
             // ... snip common code ...
        }
        logonUserId = ...;
        username = (string)args[1];
        return false;
    }
