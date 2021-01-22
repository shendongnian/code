    public class Program
    {
       public static void Main(string[] args)
       {
          byte[] byteArray = File.ReadAllBytes(@"C:/users/Alexander/image.jpg");
          ImagePartType type = byteArray.GetImageType();
       }
    }
    public static class ImageHelper
    {
        public static ImagePartType GetImageType(this byte[] imageBytes)
        {
            foreach(var imageType in imageFormatDecoders)
            {
                if (imageType.Key.SequenceEqual(imageBytes.Take(imageType.Key.Length)))
                    return imageType.Value;
            }
            throw new ArgumentException("Imagetype is unknown!");
        }
        private static Dictionary<byte[], ImagePartType> imageFormatDecoders 
                         = new Dictionary<byte[], ImagePartType>()
        {
           { new byte[]{ 0x42, 0x4D }, ImagePartType.Bmp},
           { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, ImagePartType.Gif },
           { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, ImagePartType.Gif },
           { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, ImagePartType.Png },
           { new byte[]{ 0xff, 0xd8 }, ImagePartType.Jpeg }
        };
    }
