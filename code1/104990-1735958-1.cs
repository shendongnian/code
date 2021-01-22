    private void RunMacro(object oApp, object[] oRunArgs)
    {
        oApp.GetType().InvokeMember("Run",
            System.Reflection.BindingFlags.Default |
            System.Reflection.BindingFlags.InvokeMethod,
            null, oApp, oRunArgs);
    }
