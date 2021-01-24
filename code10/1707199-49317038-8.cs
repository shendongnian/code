    public enum ImageProviders
    {
        FileSystem,
        Azure
    }
    public static class ImageProviderFactory
    {
        public static IImageProvider GetImageProvider(ImageProviders provider)
        {
            switch (provider)
            {
                case ImageProviders.FileSystem:
                    return new FSImageProvider();
                case ImageProviders.Azure:
                    return new AzureImageProvider;
                default:
                    throw new Exception("Invalid image provider");
            }
        }
    }
