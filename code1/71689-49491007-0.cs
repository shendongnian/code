    private static long? GetSizeOfObjectInBytes(object item)
    {
        if (item == null) return 0;
        try
        {
            // hackish solution to get an approximation of the size
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                MaxDepth = 10,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var formatter = new JsonMediaTypeFormatter { SerializerSettings = jsonSerializerSettings };
            using (var stream = new MemoryStream()) { 
                formatter.WriteToStream(item.GetType(), item, stream, Encoding.UTF32);
                return stream.Length / 4; // 32 bits per character = 4 bytes per character
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
