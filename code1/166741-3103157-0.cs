    public interface IRunnablePlugin : IPlugin
    {
        void RunPlugin();
    }
    
    public interface IParamRunnablePlugin : IPlugin
    {
        void RunPlugin(object parameter);
    }
