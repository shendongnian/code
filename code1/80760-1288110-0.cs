    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a file name to save the image from the Clipboard:");
            string fileName = Console.ReadLine();
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BitmapSource bitmapSource = Clipboard.GetData(System.Windows.DataFormats.Bitmap) as BitmapSource;
    
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.QualityLevel = 100;
                encoder.Save(fileStream);
            }
        }
    }
