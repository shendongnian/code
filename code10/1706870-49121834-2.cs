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
            public static ImageSource ToImageSource(System.Drawing.Image image, ImageFormat imageFormat)
            {
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream())
                {
                    // Save to the stream
                    image.Save(stream, imageFormat);
    
                    // Rewind the stream
                    stream.Seek(0, SeekOrigin.Begin);
    
                    // Tell the WPF BitmapImage to use this stream
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                }
                return bitmap;
            }
        }
    }
