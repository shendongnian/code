    public abstract class ConfigurationElementBase : ConfigurationElement
    {
        protected T GetElement<T>(string name) where T : ConfigurationElement
            => this.GetChild<T>(name);
    }
    public abstract class ConfigurationSectionBase : ConfigurationSection
    {
        protected T GetElement<T>(string name) where T : ConfigurationElement
            => this.GetChild<T>(name);
    }
    public static class ConfigurationExtensions
    {
        private static readonly Dictionary<ConfigurationElement, ConfigurationElement> Parents =
            new Dictionary<ConfigurationElement, ConfigurationElement>();
        public static T GetParent<T>(this ConfigurationElement element) where T : ConfigurationElement
            => (T)Parents[element];
        private static void SetParent(this ConfigurationElement element, ConfigurationElement parent)
            => Parents.Add(element, parent);
        private static object GetValue(this ConfigurationElement element, string name)
            => element.ElementInformation.Properties.Cast<PropertyInformation>().First(p => p.Name == name).Value;
        internal static T GetChild<T>(this ConfigurationElement element, string name) where T : ConfigurationElement
        {
            T childElement = (T)element.GetValue(name);
            if (!Parents.ContainsKey(childElement))
                childElement.SetParent(element);
            return childElement;
        }
    }
