    using System.Linq;
    namespace Sample.Extensions
    {
        public static class ByteExtensions
        {
            public static void RemoveHeader (this byte[] buffer, byte[] header)
            {
                // take first sequence of bytes, compare to header, if header
                // is present, return only content
                // 
                // NOTE: Take, SequenceEqual, and Skip are standard Linq extensions
                if (buffer.Take (header.Length).SequenceEqual (header))
                {
                    buffer = buffer.Skip (header.Length).ToArray ();
                }
            }
        }
    }
