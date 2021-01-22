    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    
    class Program
    {
        static string getMd5Hash(byte[] buffer)
        {
            MD5 md5Hasher = MD5.Create();
    
            byte[] data = md5Hasher.ComputeHash(buffer);
    
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    
        static byte[] imageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }
    
        static void Main(string[] args)
        {
            Image image = Image.FromFile(@"C:\tmp\Jellyfish.jpg");
            byte[] buffer = imageToByteArray(image);
            string md5 = getMd5Hash(buffer);
        }
    }
