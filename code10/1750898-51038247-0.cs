    .Field(nameof(file_CV),
    validate: async (state, value) =>
    {
        var val = (AwaitableAttachment)value;
    
        var url = val.Attachment.ContentUrl;
        var aname = val.Attachment.Name;
    
        HttpClient httpClient = new HttpClient();
        Stream filestrem = await httpClient.GetStreamAsync(url);
        httpClient.Dispose();
    
        var storageAccount = CloudStorageAccount.Parse("{storage_connect_string}");
        var blobClient = storageAccount.CreateCloudBlobClient();
    
        var cloudBlobContainer = blobClient.GetContainerReference("useruploads");
        await cloudBlobContainer.CreateIfNotExistsAsync();
    
        CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(aname);
    
        blockBlob.UploadFromStream(filestrem);
    
        ((AwaitableAttachment)value).Attachment.ContentUrl = blockBlob.Uri.ToString();
    
    
        var result = new ValidateResult { IsValid = true, Value = value };
        return result;
    })
