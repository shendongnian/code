    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    public sealed class SignatureDetector
    {
        public static readonly SignatureDetector Png =
            new SignatureDetector(0x89, 0x50, 0x4e, 0x47);
        
        public static readonly SignatureDetector Bmp =
            new SignatureDetector(0x42, 0x4d);
        
        public static readonly SignatureDetector Gif =
            new SignatureDetector(0x47, 0x49, 0x46);
        
        public static readonly SignatureDetector Jpeg =
            new SignatureDetector(0xff, 0xd8);
        
        public static readonly IEnumerable<SignatureDetector> Images =
            new ReadOnlyCollection<SignatureDetector>(new[]{Png, Bmp, Gif, Jpeg});
        
        private readonly byte[] bytes;
        
        public SignatureDetector(params byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            this.bytes = (byte[]) bytes.Clone();
        }
        
        public bool Matches(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (data.Length < bytes.Length)
            {
                return false;
            }
            for (int i=0; i < bytes.Length; i++)
            {
                if (data[i] != bytes[i])
                {
                    return false;
                }
            }
            return true;
        }    
    
        // Convenience method
        public static bool IsImage(byte[] data)
        {
            return Images.Any(detector => detector.Matches(data));
        }        
    }
