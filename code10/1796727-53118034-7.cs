    CefSharp.RequestContext CreateNewRequestContext (string subDirName, string host,
                                                     WebConnectionType conType)
    {
      var contextSettings = new RequestContextSettings
      {
        PersistSessionCookies = false,
        PersistUserPreferences = false,
        CachePath = Path.Combine (Cef.GetGlobalRequestContext ().CachePath, subDirName),
      };
      var context = new CefSharp.RequestContext (contextSettings);
      if (conType == WebConnectionType.Negotiate) # just an enum for UserPW + Negotiate
        Cef.UIThreadTaskFactory.StartNew (() =>
         {
           // see https://cs.chromium.org/chromium/src/chrome/common/pref_names.cc  for names
           var settings = new Dictionary<string, string>
           {
             ["auth.server_whitelist"] = $"*{host}*",
             ["auth.negotiate_delegate_whitelist"] = $"*{host}*",
             // only set-able via policies/registry :/
             // ["auth.schemes"] = "ntlm" // "basic", "digest", "ntlm", "negotiate"
           };
           // set the settings - we *trust* the host with this and allow negotiation
           foreach (var s in settings)
             if (!context.SetPreference (s.Key, s.Value, out var error))
               Log.Logger.Debug?.Log ($"Error setting '{s.Key}': {error}");
         });
      return context;
    }
