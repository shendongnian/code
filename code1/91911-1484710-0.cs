    public interface IMyPlugin
    {
        UserControl GetConfigurationControl();
    }
    
    public class SamplePlugIn: IMyPlugin
    {
        public UserControl GetConfigurationControl()
        {
            return new MyConfigurationControl();
        }
    }
    
    public class MyConfigurationControl : UserControl
    {
    }
