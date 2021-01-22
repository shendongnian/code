    public enum MediaTypes
            {
                GIF,
                MPEG
            }
    
    
    Dictionary<Enum, Type> dictionary = new Dictionary<Enum, Type>() { { MediaTypes.GIF, typeof(GifDownloader) } };
    
    public static IContentTypeDownloader Create(MediaTypes mediaType)
        {
          Type type= dictionary[mediaType];
          IContentTypeDownloader contentObject = Activator.CreateInstance(type);
           
        }
