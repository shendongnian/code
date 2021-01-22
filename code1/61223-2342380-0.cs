    public static void CopyStream(this Stream destination, Stream source)
        {
            if (source.CanSeek)
            {
                source.Position = 0;
            }
            int Length = 64000;
            Byte[] buffer = new Byte[Length];
            int bytesRead = source.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                destination.Write(buffer, 0, bytesRead);
                bytesRead = source.Read(buffer, 0, Length);
            }
        }
