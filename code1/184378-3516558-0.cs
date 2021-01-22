    [ConfigurationCollection(typeof(PluginSpec), AddItemName = "Plugin",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class PluginCollection : ConfigurationElementCollection
    {
        //This collection is potentially modified at run-time, so
        //this override prevents a "configuration is read only" exception.
        public override bool IsReadOnly()
        {
            return false;
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginSpec();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            PluginSpec retVal = element as PluginSpec;
            return retVal.Name;
        }
        public PluginSpec this[string name]
        {
            get { return base.BaseGet(name) as PluginSpec; }
        }
        public void Add(PluginSpec plugin){
            this.BaseAdd(plugin);
        }
    }
