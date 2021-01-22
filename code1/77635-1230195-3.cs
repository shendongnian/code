    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    
    namespace BitmapReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Try a small pic to be able to compare output, 
                //a big one to compare performance
                System.Drawing.Bitmap b = new 
                    System.Drawing.Bitmap(@"C:\Users\vinko\Pictures\Dibujo2.jpg"); 
                doSomethingWithBitmapSlow(b);
                doSomethingWithBitmapFast(b);
            }
    
            public static void doSomethingWithBitmapSlow(System.Drawing.Bitmap bmp)
            {
    
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color clr = bmp.GetPixel(x, y);
    
                        int red = clr.R;
                        int green = clr.G;
                        int blue = clr.B;
                        Console.WriteLine("Slow: " + red + " " 
                                           + green + " " + blue);
                    }
                }
            }
    
            public static void doSomethingWithBitmapFast(System.Drawing.Bitmap bmp)
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, 
                        System.Drawing.Imaging.ImageLockMode.ReadOnly,
                        bmp.PixelFormat);
    
                IntPtr ptr = bmpData.Scan0;
    
                int bytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[bytes];
    
                System.Runtime.InteropServices.Marshal.Copy(ptr, 
                               rgbValues, 0, bytes);
    
                byte red = 0;
                byte green = 0;
                byte blue = 0;
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        //See the link above for an explanation 
                        //of this calculation
                        int position = (y * bmpData.Stride) + (x * Image.GetPixelFormatSize(bmpData.Pixelformat)/8); 
                        blue = rgbValues[position];
                        green = rgbValues[position + 1];
                        red = rgbValues[position + 2];
                        Console.WriteLine("Fast: " + red + " " 
                                           + green + " " + blue);
                    }
                }
                bmp.UnlockBits(bmpData);
            }
        }
    }
