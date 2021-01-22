    public class Account
    {
        Dictionary<string, object> properties;
        public object this[string propertyName]
        {
            get
            {
                if (properties.ContainsKey[propertyName])
                    return properties[propertyName];
                else
                    return null;
            }
            set
            {
                properties[propertyName] = value;
            }
        }
    }
