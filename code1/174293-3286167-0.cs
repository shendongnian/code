    public class program
    {
    
        public static void Main(string[] args)
        {   
            var exeCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var dircatalog = new DirectoryCatalog(".");
            var pluginCatalog = new DirectoryCatalog("plugins");
            var aggregateCatalog = 
                new AggregateCatalog(exeCatalog, dirCatalog, pluginCatalog);
            using (var container = new CompositionContainer(aggregateCatalog))
            {
                var pluginSelectorForm = 
                    container.GetExportedValue<PluginSelectorForm>();    
                System.Windows.Forms.Application.Run(pluginSelectorForm);
            }
        }
    } 
    
    public interface IPluginMetadata
    {
        string Author { get; }
        string Category { get; }
        string Name { get; }
    }
    
    public interface IPlugin
    {
       Show();
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExportPluginAttribute : ExportAttribute, IPluginMetadata
    {
        public ExportPluginAttribute(string name)
            : base(typeof(IPlugin))
        {
            this.Name = name;
        }
     
        public string Author { get; set; }
        public string Category { get; set; }
        public string Name { get; private set; }
    }
    
    [Export]
    public class PluginSelectorForm : Form
    {
    
        [Import]
        public IEnumerable<Lazy<IPlugin, IPluginMetadata>> Plugins { get; set; }
    
        private void HandleShowPluginButtonClick()
        {
            string pluginName = GetSelectedPluginName();
            IPlugin plugin = 
                this.Plugins.Where(x => x.Metadata.Name == pluginName).Value;
            plugin.Show();
        }
        
    }
    
    [ExportPlugin("A", Author="Adam", Category="foo")]
    public class PluginA : IPlugin
    {
       [ImportingConstructor]
       public PluginA(IPluginHost host)
       {
          host.RegisterPlugin(this);
       }
    
       public void Show()
       {
       }
    }
    
    
    [ExportPlugin("B", Author="Barry", Category="bar")]
    public class PluginB : IPlugin
    {
       [ImportingConstructor]
       public PluginB(IPluginHost host)
       {
          host.RegisterPlugin(this);
       }
    
    
       public void Show()
       {
       }
    }
