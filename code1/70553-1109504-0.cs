    public static class MediaInterfaceFactory
    {
        public static IContentTypeDownloader Create(int mediaId)
        {
           switch (mediaId)
           {
                case 1:
                    return new GifDownloader();
                case 2:
                    return new MP3Downloader();
           }
        }
    }
