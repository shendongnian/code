    static void Main(string[] args)
    {
        var bytes = File.ReadAllBytes(@"...filepath...");
        var domain = AppDomain.CreateDomain("plugintest", null, null, null, false);
        var proxy = (PluginRunner)domain.CreateInstanceAndUnwrap(typeof(PluginRunner).Assembly.FullName, typeof(PluginRunner).FullName);
        proxy.LoadAssembly(bytes);
        proxy.CreateAndExecutePluginResult("TestPlugin.Class1, TestPlugin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    }
