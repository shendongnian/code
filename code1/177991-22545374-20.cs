    using CPPCallbacks;
    
    namespace SomeAppName
    {
        internal static class Callbacks
        {
            // invoked during app startup to register callbacks for unmanaged C++ code to invoke asynchronously
            internal static void RegisterCallbacks()
            {
                CPPCallbacks.CXCallbacksManager.Instance.RegisterLogMessageCallback(new LogMessageDelegate(LogMessageDelegateImpl));
                CPPCallbacks.CXCallbacksManager.Instance.RegisterGetValueForSettingCallback(new GetValueForSettingDelegate(GetValueForSettingDelegateImpl));
                // TODO: register additional callbacks as you add them
            }
            
            //-----------------------------------------------------------------
            // Callback delegate implementation methods are below; these are invoked by C++
            // Although these example implementations are in a static class, you could also pass delegate instances created 
            // from inside a non-static class, which would maintain their state just like any other class method (i.e., they have a 'this' object).
            //-----------------------------------------------------------------
    
            private static void LogMessageDelegateImpl(int level, string message)
            {
                // This next line is shown for example purposes, but at this point you can do whatever you want because 
                // you are running in a normal C# delegate context.
                Logger.WriteLine(level, message);
            }
            
            private static bool GetValueForSettingDelegateImpl(String settingName, out String settingValueOut)
            {
                // This next line is shown for example purposes, but at this point you can do whatever you want because 
                // you are running in a normal C# delegate context.
                return Utils.RetrieveEncryptedSetting(settingName, out settingValueOut);   
            }
        };
    }
