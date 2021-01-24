    [HttpPost("upload")]
    public async Task<IActionResult> GetUploadStream()
    {
        const string contentType = "application/octet-stream";
        string boundary = GetBoundary(Request.ContentType);
        MultipartReader reader = new MultipartReader(boundary, Request.Body, 80 * 1024);
        Dictionary<string, string> sectionDictionary = new Dictionary<string, string>();
        FileMultipartSection fileMultipartSection = null;
        MultipartSection section;
        while ((section = await reader.ReadNextSectionAsync()) != null)
        {
            ContentDispositionHeaderValue contentDispositionHeaderValue = section.GetContentDispositionHeader();
            if (contentDispositionHeaderValue.IsFormDisposition())
            {
                FormMultipartSection formMultipartSection = section.AsFormDataSection();
                string value = await formMultipartSection.GetValueAsync();
                sectionDictionary.Add(formMultipartSection.Name, value);
            }
            else if (contentDispositionHeaderValue.IsFileDisposition())
            {
                fileMultipartSection = section.AsFileSection(); // the file will be filled here
            }
        }
        if( fileMultipartSection == null)
        {
            return BadRequest();
        }
        CloudStorageAccount.TryParse(connectionString, out CloudStorageAccount cloudStorageAccount);
        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
        if (await cloudBlobContainer.CreateIfNotExistsAsync())
        {
            BlobContainerPermissions blobContainerPermission = new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            };
            await cloudBlobContainer.SetPermissionsAsync(blobContainerPermission);
        }
        MyFile myFile = JsonConvert.DeserializeObject<MyFile>(sectionDictionary.GetValueOrDefault(nameof(MyFile)));
        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(myFile.RelativePath);
        using(Stream blobStream = await cloudBlockBlob.OpenWriteAsync())
        {
            // Finally copy the file into the blob writable stream
            await fileMultipartSection.FileStream.CopyToAsync(blobStream);
        }
        return Ok();
    }
