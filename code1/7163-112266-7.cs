    using System;
    using System.IO;
    
    public class ImageSizeTest
    {
        public static void Main()
        {
            //for gifs
    		string gifFile = @"D:\iProduct.gif";
            FileStream f = new FileStream(gifFile, FileMode.Open, FileAccess.Read);
    
            displayGifInfo(f);
    
            f.Close();
            f = null;
    
            //for pngs
    	    string pngFile = @"D:\WaveletsGamma.png";
            f = new FileStream(pngFile, FileMode.Open, FileAccess.Read);
    
            displayPngInfo(f);
    
            f.Close();
            f = null;
    		
    	    Console.ReadLine();
        }
    
        public static void displayGifInfo(FileStream f)
        {
            string type = ((char)f.ReadByte()).ToString();
            type += ((char)f.ReadByte()).ToString();
            type += ((char)f.ReadByte()).ToString();
    
            string version = ((char)f.ReadByte()).ToString();
            version += ((char)f.ReadByte()).ToString();
            version += ((char)f.ReadByte()).ToString(); 
    
            int lower = f.ReadByte();
            int upper = f.ReadByte();
            int width = lower | upper << 8;
    
            lower = f.ReadByte();
            upper = f.ReadByte();
            int height = lower | upper << 8;        
    
    	    Console.WriteLine("GIF\nType: {0}\nVersion: {1}\nWidth: {2}\nHeight: {3}\n", type, version, width, height);
        }
    
        public static void displayPngInfo(FileStream f)
        {
            byte[] size = new byte[24];
    
            f.Read(size, 0, 24);        
    
            long width = 0;
    
            width = width | size[16];
            width = width << 8;
            width = width | size[17];
            width = width << 8;
            width = width | size[18];
            width = width << 8;
            width = width | size[19];       
    
            long height = 0;
    
            height = height | size[20];
            height = height << 8;
            height = height | size[21];
            height = height << 8;
            height = height | size[22];
            height = height << 8;
            height = height | size[23];
    
            Console.WriteLine("PNG\nWidth: {0}\nHeight: {1}\n", width, height);  
        }
    }
