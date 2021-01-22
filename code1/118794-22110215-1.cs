    public static class Utils
    {
        public static byte[] ShaHash(this Image image)
        {
            var bytes = new byte[1];
            bytes = (byte[])(new ImageConverter()).ConvertTo(image, bytes.GetType());
            return (new SHA256Managed()).ComputeHash(bytes);
        }
        public static bool AreEqual(Image imageA, Image imageB)
        {
            if (imageA.Width != imageB.Width) return false;
            if (imageA.Height != imageB.Height) return false;
            var hashA = imageA.ShaHash();
            var hashB = imageB.ShaHash();
            return !hashA
                .Where((nextByte, index) => nextByte != hashB[index])
                .Any();
        }
    ]
