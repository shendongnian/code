    using System;
    using System.Drawing;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int minimumPrintDpi = 240;
                int targetPrintWidthInches = 8;
                int targetPrintHeightInches = 10;
                int minimumImageWidth = targetPrintWidthInches * minimumPrintDpi;
                int minimumImageHeight = targetPrintHeightInches * minimumPrintDpi;
    
                var img = Image.FromFile(@"C:\temp\CaptainKangaroo.jpg");
    
                Console.WriteLine(string.Format("Minimum DPI for printing: {0}", minimumPrintDpi));
                Console.WriteLine(string.Format("Target print size: width:{0}\" x height:{1}\"", targetPrintWidthInches, targetPrintHeightInches));
                Console.WriteLine(string.Format("Minimum image horizontal resolution: {0}", minimumImageWidth));
                Console.WriteLine(string.Format("Minimum image vertical resolution: {0}", minimumImageHeight));
                Console.WriteLine(string.Format("Actual Image horizontal resolution: {0}", img.Width));
                Console.WriteLine(string.Format("Actual Image vertical resolution: {0}", img.Height));
                Console.WriteLine(string.Format("Image resolution sufficient? {0}", img.Width >= minimumImageWidth && img.Height >= minimumImageHeight));
                Console.WriteLine(string.Format("Maximum recommended print size for this image: width:{0}\" x height:{1}\"", (float)img.Width / minimumPrintDpi, (float)img.Height / minimumPrintDpi));
    
                Console.ReadKey();
            }
        }
    }
