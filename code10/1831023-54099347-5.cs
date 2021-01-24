    public class AzureStorageSettings : ISettings
    {
        [Required]
        public string ConnectionString { get; set; }
        [Required]
        public string Container { get; set; }
        [Required]
        public string Path { get; set; }
    }
