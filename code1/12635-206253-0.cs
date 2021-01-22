    private static PluginInfo _PluginInfo = null;
    public static IPluginInfo PluginInfo
    {
        get
        {
            if (_PluginInfo == null)
            {
               _PluginInfo = new PluginInfo();
               _PluginInfo.Name = "PluginName";
               _PluginInfo.Version = "PluginVersion";
            }
            return _PluginInfo;
        }
    }
