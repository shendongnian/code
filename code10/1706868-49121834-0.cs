    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace StackCsWpf
    {
        public class ImageUtils
        {
            public static ImageSource toImageSource(System.Drawing.Image image, ImageFormat imageFormat)
            {
                BitmapImage bitMapImg = new BitmapImage();
                bitMapImg.BeginInit();
                MemoryStream stream = new MemoryStream();
    
                // Save to the stream
                image.Save(stream, imageFormat);
    
                // Rewind the stream
                stream.Seek(0, SeekOrigin.Begin);
    
                // Tell the Wpf image to use this stream
                bitMapImg.StreamSource = stream;
    
                bitMapImg.EndInit();
    
                return bitMapImg;
            }
        }
    }
