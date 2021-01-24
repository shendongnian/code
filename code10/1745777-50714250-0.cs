    public class MyClass{
        private readonly string _jsonPath= ...;
        private readonly StorageClient _storageClient;
        public MyClass()
        {
            var credential = GoogleCredential.FromFile(_jsonPath);
            _storageClient = StorageClient.Create(credential);
        }
        public Task<string> UploadAsync(/*my parameter*/)
        {
            var imageObject = await _storageClient.UploadObjectAsync(...);
            // etc
        }
    }
