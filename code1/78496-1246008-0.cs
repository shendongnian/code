    public static class ImageHelper
    {
        public static ImageFormat GetContentType(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            using (BinaryReader br = new BinaryReader(ms))
            {
                int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;
                byte[] magicBytes = new byte[maxMagicBytesLength];
                for (int i = 0; i < maxMagicBytesLength; i += 1)
                {
                    magicBytes[i] = br.ReadByte();
                    foreach (var kvPair in imageFormatDecoders)
                    {
                        if (magicBytes.StartsWith(kvPair.Key))
                        {
                            return kvPair.Value;
                        }
                    }
                }
                throw new ArgumentException("Could not recognise image format", "binaryReader");
            }
        }
        private static bool StartsWith(this byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }
            return true;
        }
        private static Dictionary<byte[], ImageFormat> imageFormatDecoders = new Dictionary<byte[], ImageFormat>()
        {
            { new byte[]{ 0x42, 0x4D }, ImageFormat.Bmp},
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, ImageFormat.Gif },
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, ImageFormat.Gif },
            { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, ImageFormat.Png },
            { new byte[]{ 0xff, 0xd8 }, ImageFormat.Jpeg },
        };
