            Image img = Image.FromFile(fileName);
            ImageFormat format = img.RawFormat;
            Console.WriteLine("Image Type : "+format.ToString());
            Console.WriteLine("Image width : "+img.Width);
            Console.WriteLine("Image height : "+img.Height);
            Console.WriteLine("Image resolution : "+(img.VerticalResolution*img.HorizontalResolution));
    
            Console.WriteLine("Image Pixel depth : "+Image.GetPixelFormatSize(img.PixelFormat));
            Console.WriteLine("Image Creation Date : "+creation.ToString("yyyy-MM-dd"));
            Console.WriteLine("Image Creation Time : "+creation.ToString("hh:mm:ss"));
            Console.WriteLine("Image Modification Date : "+modify.ToString("yyyy-MM-dd"));
            Console.WriteLine("Image Modification Time : "+modify.ToString("hh:mm:ss"));
            
