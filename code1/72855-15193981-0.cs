    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class ProviderIconAttribute : Attribute
    {
        public Image ProviderIcon { get; protected set; }
        public ProviderIconAttribute(Type resourceType, string resourceName)
        {
            var value = ResourceHelper.GetResourceLookup<Image>(resourceType, resourceName);
            this.ProviderIcon = value;
        }
    }
        //From http://stackoverflow.com/questions/1150874/c-sharp-attribute-text-from-resource-file
        //Only thing I changed was adding NonPublic to binding flags since our images come from other dll's
        // and making it generic, as the original only supports strings
        public class ResourceHelper
        {
            public static T GetResourceLookup<T>(Type resourceType, string resourceName)
            {
                if ((resourceType != null) && (resourceName != null))
                {
                    PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
                    if (property == null)
                    {
                        return default(T);
                    }
                    return (T)property.GetValue(null, null);
                }
                return default(T);
            }
        }
