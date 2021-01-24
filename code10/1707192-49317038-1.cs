    public class ImageProviderSection : ConfigurationSection
    {
        public const string ImageProviderConfigurationSection = "imageProviderConfiguration";
        public const string ImageProviderProperty = "imageProvider";
        public const string FSImageProviderProperty = "fsImageProvider";
        public const string AzureImageProviderProperty = "azureImageProvider";
        [ConfigurationProperty(ImageProviderProperty)]
        public ImageProviderElement ImageProvider
        {
            get { return (ImageProviderElement)this[ImageProviderProperty]; }
            set { this[ImageProviderProperty] = value; }
        }
        [ConfigurationProperty(FSImageProviderProperty)]
        public FSImageProviderElement FSImageProvider
        {
            get { return (FSImageProviderElement)this[FSImageProviderProperty]; }
            set { this[FSImageProviderProperty] = value; }
        }
        [ConfigurationProperty(AzureImageProviderProperty)]
        public AzureImageProviderElement AzureImageProvider
        {
            get { return (AzureImageProviderElement)this[AzureImageProviderProperty]; }
            set { this[AzureImageProviderProperty] = value; }
        }
    }
    public class ImageProviderElement : ConfigurationElement
    {
        private const string nameProperty = "name";
        [ConfigurationProperty(nameProperty, IsRequired = true)]
        public string Name
        {
            get { return (string)this[nameProperty]; }
            set { this[nameProperty] = value; }
        }
    }
    public class FSImageProviderElement : ConfigurationElement
    {
        private const string directoryProperty = "directory";
        [ConfigurationProperty(directoryProperty, IsRequired = true)]
        public string Directory
        {
            get { return (string)this[directoryProperty]; }
            set { this[directoryProperty] = value; }
        }
    }
    public class AzureImageProviderElement : ConfigurationElement
    {
        private const string azureKeyProperty = "azureKey";
        private const string storageAccountNameProperty = "storageAccountName";
        [ConfigurationProperty(azureKeyProperty, IsRequired = true)]
        public string AzureKey
        {
            get { return (string)this[azureKeyProperty]; }
            set { this[azureKeyProperty] = value; }
        }
        [ConfigurationProperty(storageAccountNameProperty, IsRequired = true)]
        public string StorageAccountName
        {
            get { return (string)this[storageAccountNameProperty]; }
            set { this[storageAccountNameProperty] = value; }
        }
    }
