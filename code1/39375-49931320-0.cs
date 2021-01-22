    /// <summary>
    /// This holds all of the session variables for the site.
    /// </summary>
    public class SessionCentralized
    {
    protected internal static void Save<T>(string sessionName, T value)
    {
        HttpContext.Current.Session[sessionName] = value;
    }
    
    protected internal static T Get<T>(string sessionName)
    {
        return (T)HttpContext.Current.Session[sessionName];
    }
    
    public static int? WhatEverSessionVariableYouWantToHold
    {
        get
        {
            return Get<int?>(nameof(WhatEverSessionVariableYouWantToHold));
        }
        set
        {
            Save(nameof(WhatEverSessionVariableYouWantToHold), value);
        }
    }
    }
