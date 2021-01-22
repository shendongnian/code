    public class RetryTurnCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return element;
        }
        ...
    }
