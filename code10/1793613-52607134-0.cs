    // Get a blob reference to write this file to
    var blob = container.GetBlockBlobReference(key);
    // If the blob already exists
    if (await blob.ExistsAsync()) {
        // Fetch the blob's properties
        await blob.FetchAttributesAsync();
        // Only proceed if modification time of local file is newer
        if (blob.Properties.LastModified > File.GetLastWriteTimeUtc(filePath))
            return;
    }
