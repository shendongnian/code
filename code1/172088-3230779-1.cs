    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    
    namespace Playground
    {
        public class Program
        {
            static void Main(string[] args)
            {
                PluginHost host = new PluginHost();
                host.PrintListOfPlugins();
                Console.ReadKey();
            }
        }
    
        public class PluginHost
        {
            [ImportMany]
            public IEnumerable<IPlugin> Plugins { get; set; }
    
            public PluginHost()
            {
                var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
    
            public void PrintListOfPlugins()
            {
                foreach (IPlugin plugin in Plugins)
                    Console.WriteLine(plugin.Description);
            }
        }
    
        public interface IPlugin
        {
            string Description { get; }
        }
    
        [Export(typeof(IPlugin))]
        public class ExamplePlugin : IPlugin
        {
            #region IPlugin Members
    
            public string Description
            {
                get { return "I'm an example plugin!"; }
            }
    
            #endregion
        }
    }
