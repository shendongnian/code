    public class PluginVM : ObservableObjectExt
    {
        public PluginVM(IPlugin plugin)
        {
            this.Plugin = plugin;
            this.IsEnabled = true;
        }
        public IPlugin Plugin { get; private set; }
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set {
                isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }
    }
