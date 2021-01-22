        // Return the length of a stream that does not have a usable Length property
        public static int GetStreamLength(Stream stream)
        {
            long originalPosition = 0;
            int totalBytesRead = 0;
            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }
            try
            {
                byte[] readBuffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = stream.Read(readBuffer, 0, 4096)) > 0)
                {
                    totalBytesRead += bytesRead;
                }
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
            return totalBytesRead;
        }
