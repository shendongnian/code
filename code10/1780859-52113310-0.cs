    using Microsoft.AspNetCore.ResponseCompression;
    using System.IO;
    using System.IO.Compression;
     
    namespace CompressionApp
    {
        public class DeflateCompressionProvider : ICompressionProvider
        {
            public string EncodingName => "deflate";
            public bool SupportsFlush => true;
     
            public Stream CreateStream(Stream outputStream)
            {
                return new DeflateStream(outputStream, CompressionLevel.Optimal);
            }
        }
    }
