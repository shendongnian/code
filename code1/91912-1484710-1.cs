    public interface IMyPlugin
    {
        void ConfigurePlugin();
    }
        
    public class SamplePlugIn: IMyPlugin
    {
        public void ConfigurePlugin()
        {
            using(YourPluginConfigurationForm dlg = new YourPluginConfigurationForm())
            {
                 dlg.ShowDialog();
            }
        }
    }
