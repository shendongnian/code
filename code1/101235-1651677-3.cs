    public class ProviderCollection : ConfigurationElementCollection
    {
        public ProviderElement this[object elementKey]
        {
            get { return BaseGet(elementKey); }
        }
        
        public void Add(ProviderElement provider)
        {
            base.BaseAdd(provider);
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProviderElement();
        }
       
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProviderElement)element).Key;
        }
        protected override string ElementName
        {
            get { return "Provider"; }
        }
    }
