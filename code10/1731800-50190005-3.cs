    public class ValetKeyResponse : IValetKeyResponse
    {
        public IStorageEntitySas Sas { get; set; } = new StorageEntitySas();
        public string UploadUrl { get; set; }
    }
