    using System.ComponentModel;
    using System.Configuration;
    public static class SettingsExtensions
    {
        public static object GetDefaultValue(this ApplicationSettingsBase settings,
            string propertyName)
        {
            var property = settings.Properties[propertyName];
            var type = property.PropertyType;
            var defaultValue = property.DefaultValue;
            return TypeDescriptor.GetConverter(type).ConvertFrom(defaultValue);
        }
    }
