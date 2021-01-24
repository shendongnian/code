    [ConfigurationCollection(typeof(PersonConfiguration))]
    public class PersonConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override PersonConfiguration CreateNewElement()
        {
            return new PersonConfiguration();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PersonConfiguration)element).Name;
        }
    }
