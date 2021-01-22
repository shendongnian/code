    using System;
    using System.Drawing;
    
    namespace BitmapDpi
    {
        class Program
        {
            static void Main(string[] args)
            {
                Bitmap bmp = new Bitmap("winter.jpg");
                Console.WriteLine("Image resolution: " + bmp.HorizontalResolution + "DPI");
            }
        }
    }
