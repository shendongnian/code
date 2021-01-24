    public interface IImageProvider
    {
        void Save(string filename, byte[] imageData);
        byte[] Get(string filename);
        void Delete(string filename);
    }
    public class FSImageProvider : IImageProvider
    {
        private string _directory = string.Empty;
        public FSImageProvider()
        {
            ImageProviderSection imageProviderSection = ConfigurationManager.GetSection(ImageProviderSection.ImageProviderConfigurationSection) as ImageProviderSection;
            _directory = imageProviderSection.FSImageProvider.Directory.Trim();
            if (!_directory.EndsWith("\\"))
                _directory += "\\";
        }
        public void Delete(string filename)
        {
            File.Delete(_directory + filename);
        }
        public byte[] Get(string filename)
        {
            return File.ReadAllBytes(_directory + filename);
        }
        public void Save(string filename, byte[] imageData)
        {
            File.WriteAllBytes(_directory + filename, imageData);
        }
    }
    public class AzureImageProvider : IImageProvider
    {
        private string _azureKey = string.Empty;
        private string _storageAccountName = string.Empty;
        public AzureImageProvider()
        {
            ImageProviderSection imageProviderSection = ConfigurationManager.GetSection(ImageProviderSection.ImageProviderConfigurationSection) as ImageProviderSection;
            _azureKey = imageProviderSection.AzureImageProvider.AzureKey;
            _storageAccountName = imageProviderSection.AzureImageProvider.StorageAccountName;
        }
        public void Delete(string filename)
        {
            throw new NotImplementedException();
        }
        public byte[] Get(string filename)
        {
            throw new NotImplementedException();
        }
        public void Save(string filename, byte[] imageData)
        {
            throw new NotImplementedException();
        }
    }
