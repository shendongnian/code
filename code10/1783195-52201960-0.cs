    public class PluginRunner
    {
        public class PluginMessageEventArgs
        {
            public string Text { get; set; }
        }
        public event EventHandler<PluginMessageEventArgs> PluginMessage;
        public void Run( string pluginPath )
        {
            Assembly PlugInDLL = Assembly.LoadFile(pluginPath);
            Object Objekt = PlugInDLL.CreateInstance("DLL.PlugIn");
            MethodInfo Info1 = Objekt.GetType().GetMethod("Programm");
            Info1.Invoke(Objekt, new Object[] { Projekt, TIAInstanz, new Action<string>(Log) });
        }
        private void Log(string s)
        {
            PluginMessage?.Invoke(this, new PluginMessageEventArgs { Text = s });
        }
    }
	
