     public  static string MimeTypeFrom(byte[] dataBytes, string fileName)
     {
            var contentType = HeyRed.Mime.MimeGuesser.GuessMimeType(dataBytes);
            if (string.IsNullOrEmpty(contentType))
            {
                return HeyRed.Mime.MimeTypesMap.GetMimeType(fileName);
            }
      return contentType;
