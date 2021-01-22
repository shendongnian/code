    public interface IPlugin
    {
    void Run(PluginHost browser);
    }
    
    public class PluginHost
    {
    public void RunPlugins (IPlugin[] plugins)
    {
    foreach plugin in plugins
    {
    plugin.Run(this);
    }
    }
    }
