    [Serializable] //This is important
    public class TPlugin
    {
        public bool InitializeImmediately { get; set; }
        public AppDomainSetup AppSetup { get; set; }
        public Assembly Assembly { get; set; }
        public AppDomain AppDomain { get; set; }
        public string FilePath { get; set; }
        public object ClassInstance { get; set; }
        public Type ClassType { get; set; }
    
        public TPlugin(string path, bool Initialize = false)
        {
            FilePath = path;
            InitializeImmediately = Initialize;
    
            AppSetup = new AppDomainSetup();
            AppSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain = AppDomain.CreateDomain(FilePath, null, AppSetup);
            AppDomain.SetData("Plugin", this);
            AppDomain.DoCallBack(new CrossAppDomainDelegate(() =>
            {
                //We are now inside the new AppDomain, every other variable is now invalid since this AppDomain cannot see into the main one
                TPlugin plugin = AppDomain.CurrentDomain.GetData("Plugin") as TPlugin;
                if (plugin != null)
                {
                    plugin.Assembly = Assembly.LoadFrom(plugin.FilePath);
                    if(InitializeImmediately) //You cannot use the "Initialize" parameter here, it goes out of scope for this AppDomain
                    {
                        plugin.ClassType = plugin.Assembly.GetExportedTypes()[0];
                        if (plugin.ClassType != null && plugin.ClassType.IsClass)
                        {
                            plugin.ClassInstance = Activator.CreateInstance(plugin.ClassType);
                            MethodInfo info = plugin.ClassType.GetMethod("Initializer");
                            info.Invoke(plugin.ClassInstance, null);
                        }
                    }
                }
            }));
        }
    
        public object Execute(string FunctionName, params object[] args)
        {
            AppDomain.SetData("FunctionName", FunctionName);
            AppDomain.SetData("FunctionArguments", args);
            AppDomain.DoCallBack(CallBack);
            return AppDomain.GetData("FunctionReturn");
        }
    
        public void CallBack()
        {
            TPlugin plugin = AppDomain.CurrentDomain.GetData("Plugin") as TPlugin;
    
            if (plugin != null)
            {
                MethodInfo info = plugin.ClassType.GetMethod(AppDomain.CurrentDomain.GetData("FunctionName") as string);
                info.Invoke(plugin.ClassInstance, AppDomain.CurrentDomain.GetData("FunctionArgs") as object[]);
            }
    
            //This is how to return back since DoCallBack does not support returns.
            AppDomain.CurrentDomain.SetData("FunctionReturn", null);
        }
    }
