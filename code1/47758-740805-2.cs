    namespace PluginTest
    {
        using System;
        using System.IO;
        using System.Runtime.Remoting;
        using PluginInterface;
    
        class Program
        {
            static void Main( string[] args )
            {
                string pluginFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PluginX.dll");
                ObjectHandle handle = Activator.CreateInstanceFrom(pluginFile, "PluginX.Plugin");
    
                IPlugin plugin = handle.Unwrap() as IPlugin;
    
                string pluginName = plugin.Name;
                string pluginResult = plugin.Run("test string");          
                
            }
        }
    }
