    public static void ListContainerMetadataAsync(CloudBlobContainer container)
    {
        // Fetch container attributes in order to populate the container's 
           properties and metadata.
         container.FetchAttributes();
    
        // Enumerate the container's metadata.
        Console.WriteLine("Container metadata:");
        foreach (var metadataItem in container.Metadata)
        {
            Console.WriteLine("\tKey: {0}", metadataItem.Key);
            Console.WriteLine("\tValue: {0}", metadataItem.Value);
        }
    }
