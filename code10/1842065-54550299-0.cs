    [Singleton]
    public static async Task ProcessImage([BlobTrigger("images")] Stream image)
    {
         // Process the image
    }
