    var original = new byte[65535];
    var compressed = GZipTest.Compress(original);
    var decompressed = GZipTest.Decompress(compressed);
-----------------------
    using System.IO;
    using System.IO.Compression;
    
    public class GZipTest
    {
        public static byte[] Compress(byte[] uncompressedBuffer)
        {
            using (var ms = new MemoryStream())
            {
                using (var gzip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    gzip.Write(uncompressedBuffer, 0, uncompressedBuffer.Length);
                }
                byte[] compressedBuffer = ms.ToArray();
                return compressedBuffer;
            }
        }
    
        public static byte[] Decompress(byte[] compressedBuffer)
        {
            using (var gzip = new GZipStream(new MemoryStream(compressedBuffer), CompressionMode.Decompress))
            {
                byte[] uncompressedBuffer = ReadAllBytes(gzip);
                return uncompressedBuffer;
            }
        }
    
        private static byte[] ReadAllBytes(Stream stream)
        {
            var buffer = new byte[4096];
            using (var ms = new MemoryStream())
            {
                int bytesRead = 0;
                do
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }
                } while (bytesRead > 0);
    
                return ms.ToArray();
            }
        }
    }
