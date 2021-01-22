        public static Stream Copy(this Stream source)
        {
            if (source == null)
                return null;
            long originalPosition = -1;
            if (source.CanSeek)
                originalPosition = source.Position;
            MemoryStream ms = new MemoryStream();
            try
            {
                Copy(source, ms);
                if (originalPosition > -1)
                    ms.Seek(originalPosition, SeekOrigin.Begin);
                else
                    ms.Seek(0, SeekOrigin.Begin);
                return ms;
            }
            catch
            {
                ms.Dispose();
                throw;
            }
        }
        public static void Copy(this Stream source, Stream target)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (target == null)
                throw new ArgumentNullException("target");
            long originalSourcePosition = -1;
            int count = 0;
            byte[] buffer = new byte[0x1000];
            if (source.CanSeek)
            {
                originalSourcePosition = source.Position;
                source.Seek(0, SeekOrigin.Begin);
            }
            while ((count = source.Read(buffer, 0, buffer.Length)) > 0)
                target.Write(buffer, 0, count);
            if (originalSourcePosition > -1)
            {
                source.Seek(originalSourcePosition, SeekOrigin.Begin);
            }
        }
