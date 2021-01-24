    public static class ImageProviderFactory
    {
        public static IImageProvider GetImageProvider()
        {
            ImageProviderSection imageProviderSection = ConfigurationManager.GetSection(ImageProviderSection.ImageProviderConfigurationSection) as ImageProviderSection;
            switch (imageProviderSection.ImageProvider.Name)
            {
                case ImageProviderSection.FSImageProviderProperty:
                    return new FSImageProvider();
                case ImageProviderSection.AzureImageProviderProperty:
                    return new AzureImageProvider;
                default:
                    throw new Exception("Invalid image provider in configuration");
            }
        }
    }
