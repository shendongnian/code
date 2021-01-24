    public class AzureBlobModel
    {
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public Stream Stream { get; set; }
        public string ContentType { get; set; }
    }
    public interface IImageStore
    {
        Task<string> SaveDocument(Stream documentStream);
        Task<bool> DeleteDocument(string imageId);
        Task<AzureBlobModel> DownloadDocument(string documentId, string fileName);
        string UriFor(string documentId);
    }
    public class ImageStore : IImageStore
    {
        CloudBlobClient blobClient;
        string baseUri = "https://xxxxx.blob.core.windows.net/";
        public ImageStore()
        {
            var credentials = new StorageCredentials("xxxxx accountName xxxxx", "xxxxx keyValue xxxxx");
            blobClient = new CloudBlobClient(new Uri(baseUri), credentials);
        }
        public async Task<string> SaveDocument(Stream documentStream)
        {
            var documentId = Guid.NewGuid().ToString();
            var container = blobClient.GetContainerReference("xxxxx container xxxxx");
            var blob = container.GetBlockBlobReference(documentId);
            await blob.UploadFromStreamAsync(documentStream);
            return documentId;
        }
        public async Task<bool> DeleteDocument(string documentId)
        {
            var container = blobClient.GetContainerReference("xxxxx container xxxxx");
            var blob = container.GetBlockBlobReference(documentId);
            bool blobExisted = await blob.DeleteIfExistsAsync();
            return blobExisted;
        }
        public async Task<AzureBlobModel> DownloadDocument(string documentId, string fileName)
        {
            var container = blobClient.GetContainerReference("xxxxx container xxxxx");
            var blob = container.GetBlockBlobReference(documentId);
            var doc = new AzureBlobModel()
            {
                FileName = fileName,
                Stream = new MemoryStream(),
            };
            doc.Stream = await blob.OpenReadAsync();
            doc.ContentType = blob.Properties.ContentType;
            doc.FileSize = blob.Properties.Length;
            return doc;
        }
        public string UriFor(string documentId)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.UtcNow.AddDays(1)
            };
            var container = blobClient.GetContainerReference("xxxxx container xxxxx");
            var blob = container.GetBlockBlobReference(documentId);
            var sas = blob.GetSharedAccessSignature(sasPolicy);
            return $"{baseUri}xxxxx container xxxxx/{documentId}{sas}";
        }
    }
	public class DocForCreationDto
    {
        public IFormFile File { get; set; }
        // other properties ...
    }
	
    // On the controller
	
    [HttpPost]
    public async Task<IActionResult> Upload([FromForm]DocForCreationDto docForCreationDto)
    {
        if (docForCreationDto.File == null || !ModelState.IsValid)
        {
            return new UnprocessableEntityObjectResult(ModelState);
        }
        string documentId = string.Empty;
        using (var stream = docForCreationDto.File.OpenReadStream())
        {
            documentId = await _imageStore.SaveDocument(stream);
        }
        if (documentId != string.Empty)
        {
            // upload ok ...
            //some business logic here ...
            return Ok();
        }
        return BadRequest("xxx error xxx");
    }
	
    [HttpGet("{documentId}", Name = "GetDocument")]
    public async Task<IActionResult> GetDocument(int documentId)
    {
        var doc = await _imageStore.DownloadDocument(documentId, "output filename");
        return File(doc.Stream, doc.ContentType, doc.FileName);
    }
    // On Startup - ConfigureServices
    services.AddSingleton<IImageStore, ImageStore>();
