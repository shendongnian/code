    public class CustomSettingsHandler : ConfigurationSection
    {
        // ...
       
        protected override void PostDeserialize()
        {
            foreach (ConfigurationProperty property in Properties)
            {
                var configElement = this[property] as ConfigurationElement;
                if (configElement != null 
                    && !configElement.ElementInformation.IsPresent)
                {
                    this[property] = null;
                }
            }
            base.PostDeserialize();
        }
    }
