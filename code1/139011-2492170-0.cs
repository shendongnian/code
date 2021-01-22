    private void ProcessMissingElements(ConfigurationElement element)
    {
        foreach (PropertyInformation propertyInformation in element.ElementInformation.Properties)
        {
            var complexProperty = propertyInformation.Value as ConfigurationElement;
            if (complexProperty == null) 
                continue;
            if (propertyInformation.IsRequired && !complexProperty.ElementInformation.IsPresent)
                throw new ConfigurationErrorsException("ConfigProperty: [{0}] is required but not present".FormatStr(propertyInformation.Name));
            if (!complexProperty.ElementInformation.IsPresent)
                propertyInformation.Value = null;
            else
                ProcessMissingElements(complexProperty);
        }
    }
