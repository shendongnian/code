    public interface IRunnablePlugin : IPlugin
    {
        XmlDocument RunPlugin();
    }
    
    public interface IParamRunnablePlugin : IPlugin
    {
        XmlDocument RunPlugin(object parameter);
    }
