    public async Task<string> CreateAsync(HttpRequestMessage request, string containerName, string directoryName, string existingUrl = "")
    {
        if (!request.Content.IsMimeMultipartContent("form-data")) throw new HttpResponseException(request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
        Valiate(containerName, directoryName);
        var filesReadToProvider = await request.Content.ReadAsMultipartAsync();
        // We assume that the form data name is file and metadata respectively
        var fileStream = filesReadToProvider.Contents.SingleOrDefault(m => 
            m.Headers.ContentDisposition.Name.Equals("\"file\"", StringComparison.OrdinalIgnoreCase) ||
            m.Headers.ContentDisposition.Name.Equals("file", StringComparison.OrdinalIgnoreCase));
        var metaDataStream = filesReadToProvider.Contents.SingleOrDefault(m =>
            m.Headers.ContentDisposition.Name.Equals("\"metadata\"", StringComparison.OrdinalIgnoreCase) ||
            m.Headers.ContentDisposition.Name.Equals("metadata", StringComparison.OrdinalIgnoreCase));
        if (fileStream == null) throw new ArgumentNullException(nameof(fileStream));
        if (metaDataStream == null) throw new ArgumentNullException(nameof(metaDataStream));
        // Upload our file
        var fileBytes = await fileStream.ReadAsByteArrayAsync();
        var mediaType = fileStream.Headers.ContentType.MediaType;
        var friendlyFileName = fileStream.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(friendlyFileName)}";
        var directory = GetDirectory(containerName, directoryName);
        var fileUrl = await Upload(directory, fileName, mediaType, fileBytes);
        // Add our metadata
        var metadata = await GetMetadataFromMemoryStreamAsync(metaDataStream);
        metadata.Add("fileName", friendlyFileName);
        metadata.Add("directory", directoryName);
        metadata.Add("created", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
        await AddFileMetaDataAsync(fileUrl, metadata);
        // Delete any existing file
        if (!string.IsNullOrEmpty(existingUrl) && fileUrl != existingUrl) await DeleteAsync(containerName, directoryName, existingUrl);
        return fileUrl;
    }
