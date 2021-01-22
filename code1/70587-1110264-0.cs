    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace ImageDownloader
    {
        class Program
        {
            static void Main(string[] args)
            {
                string imageUrl = @"http://www.somedomain.com/image.jpg";
                string saveLocation = @"C:\someImage.jpg";
    
                byte[] imageBytes;
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                WebResponse imageResponse = imageRequest.GetResponse();
    
                Stream stream = imageResponse.GetResponseStream();
    
                using (BinaryReader br = new BinaryReader(stream))
                {
                    imageBytes = br.ReadBytes(500000);
                    br.Close();
                }
                imageResponse.Close();
    
                FileStream fs = new FileStream(saveLocation, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                try
                {
                    bw.Write(imageBytes);
                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
            }
        }
    }
