    public static async Task AddContainerMetadataAsync(CloudBlobContainer container)
    {
       // Add some metadata to the container.
       container.Metadata.Add("docType", "textDocuments");
       container.Metadata["category"] = "guidance";
       // Set the container's metadata.
       await container.SetMetadataAsync();
    }
