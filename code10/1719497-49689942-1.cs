    #r "Microsoft.WindowsAzure.Storage"
    using ImageResizer;
    using Microsoft.WindowsAzure.Storage.Blob;
    
    public static async Task Run(
    Stream image,   // input blob, large size
    Binder binder,string blobname,string blobextension,TraceWriter log)  // output blobs
    {
        var attributes = new Attribute[]
        {    
            new BlobAttribute($"container/{blobname}.{blobextension}"),
            
            new StorageAccountAttribute("joeystorage") //connection string name for storage connection
        };
        CloudBlockBlob blob =await binder.BindAsync<CloudBlockBlob>(attributes);
        var imageBuilder = ImageResizer.ImageBuilder.Current;
        var size = imageDimensionsTable[ImageSize.Small];
    
        Stream outStream=new MemoryStream();
        imageBuilder.Build(
           image,outStream,
           new ResizeSettings(size.Item1, size.Item2, FitMode.Max, null),false);
          blob.UploadFromStream(outStream);
    }
    
    public enum ImageSize
    {
      ExtraSmall, Small, Medium
    }
    
    private static Dictionary<ImageSize, Tuple<int, int>> imageDimensionsTable = new Dictionary<ImageSize, Tuple<int, int>>()
        {
            { ImageSize.ExtraSmall, Tuple.Create(320, 200) },
            { ImageSize.Small,      Tuple.Create(640, 400) },
            { ImageSize.Medium,     Tuple.Create(800, 600) }
        }; 
