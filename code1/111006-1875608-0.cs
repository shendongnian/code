    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    
    namespace BitmapSimilarity
    {
        public interface IBitmapCompare
        {
            double GetSimilarity(Bitmap a, Bitmap b);
        }
    
        class BitmapCompare: IBitmapCompare
        {
            public struct RGBdata
            {
                public int r;
                public int g;
                public int b;
    
                public int GetLargest()
                {
                    if(r>b)
                    {
                        if(r>g)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
    
            private RGBdata ProcessBitmap(Bitmap a)
            {
                BitmapData bmpData = a.LockBits(new Rectangle(0,0,a.Width,a.Height),ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);
                IntPtr ptr = bmpData.Scan0;
                RGBdata data = new RGBdata();
    
                unsafe
                {
                    byte* p = (byte*)(void*)ptr;
                    int offset = bmpData.Stride - a.Width * 3;
                    int width = a.Width * 3;
    
                    for (int y = 0; y < a.Height; ++y)
                    {
                        for (int x = 0; x < width; ++x)
                        {
                            data.r += p[0];             //gets red values
                            data.g += p[1];             //gets green values
                            data.b += p[2];             //gets blue values
                            ++p;
                        }
                        p += offset;
                    }
                }
                a.UnlockBits(bmpData);
                return data;
            }
    
            public double GetSimilarity(Bitmap a, Bitmap b)
            {
                RGBdata dataA = ProcessBitmap(a);
                RGBdata dataB = ProcessBitmap(b);
                double result = 0;
                int averageA = 0;
                int averageB = 0;
                int maxA = 0;
                int maxB = 0;
    
                maxA = ((a.Width * 3) * a.Height);
                maxB = ((b.Width * 3) * b.Height);
    
                switch (dataA.GetLargest())            //Find dominant color to compare
                {
                    case 1:
                        {
                            averageA = Math.Abs(dataA.r / maxA);
                            averageB = Math.Abs(dataB.r / maxB);
                            result = (averageA - averageB) / 2;
                            break;
                        }
                    case 2:
                        {
                            averageA = Math.Abs(dataA.g / maxA);
                            averageB = Math.Abs(dataB.g / maxB);
                            result = (averageA - averageB) / 2;
                            break;
                        }
                    case 3:
                        {
                            averageA = Math.Abs(dataA.b / maxA);
                            averageB = Math.Abs(dataB.b / maxB);
                            result = (averageA - averageB) / 2;
                            break;
                        }
                }
    
                result = Math.Abs((result + 100) / 100);
    
                if (result > 1.0)
                {
                    result -= 1.0;
                }
    
                return result;
            }
        }
    
        class Program
        {
            static BitmapCompare SimpleCompare;
            static Bitmap searchImage;
    
            static private void Line()
            {
                for (int x = 0; x < Console.BufferWidth; x++)
                {
                    Console.Write("*");
                }
            }
    
            static void CheckDirectory(string directory,double percentage,Bitmap sImage)
            {
                DirectoryInfo dir = new DirectoryInfo(directory);
                FileInfo[] files = null;
                try
                {
                    files = dir.GetFiles("*.jpg");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Bad directory specified");
                    return;
                }
                
                double sim = 0;
    
                foreach (FileInfo f in files)
                {
                    sim = Math.Round(SimpleCompare.GetSimilarity(sImage, new Bitmap(f.FullName)),3);
                    if (sim >= percentage)
                    {
                        Console.WriteLine(f.Name);
                        Console.WriteLine("Match of: {0}", sim);
                        Line(); 
                    }
                }
            }
    
            static void Main(string[] args)
            {
                SimpleCompare = new BitmapCompare();
                Console.Write("Enter path to search image: ");
                try
                {
                    searchImage = new Bitmap(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Bad file");
                    return;
                }
                
                Console.Write("Enter directory to scan: ");
                string dir = Console.ReadLine();
                Line();
                CheckDirectory(dir, 0.95 , searchImage);        //Display only images that match by 95%
            }
        }
    }
