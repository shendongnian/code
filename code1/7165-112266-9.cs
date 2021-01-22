    using System;
    using System.IO;
    using System.Text;
    
    public class ImageSizeTest
    {
        public static void Main()
        {
    		byte[] bytes = null;
    		
    		string gifFile = @"D:\iProduct.gif";
            bytes = new byte[10];
    		using (FileStream fs = File.OpenRead(gifFile))
    		{
    			fs.Read(bytes, 0, 10); // type (3 bytes), version (3 bytes), width (2 bytes) and height (2 bytes)
    		}
    		displayGifInfo(bytes);
    
    		string pngFile = @"D:\WaveletsGamma.png";
    		bytes = new byte[8];
    		using (FileStream fs = File.OpenRead(pngFile))
    		{
    			fs.Seek(16, SeekOrigin.Begin); // jump to the 16th byte where width and height information is stored
    			fs.Read(bytes, 0, 8); // 4 bytes for width and height each
    		}
    	    displayPngInfo(bytes);
        }
    
        public static void displayGifInfo(byte[] bytes)
        {
    		string type = Encoding.ASCII.GetString(bytes, 0, 3);
            string version = Encoding.ASCII.GetString(bytes, 3, 3);
    
            int lower = bytes[6];
            int upper = bytes[7];
            int width = lower | upper << 8; // byte 6 and 7 contain the width but in network byte order so they have to be flipped over
    
            lower = bytes[8];
            upper = bytes[9];
            int height = lower | upper << 8; // same for height
    
    		Console.WriteLine("GIF\nType: {0}\nVersion: {1}\nWidth: {2}\nHeight: {3}\n", type, version, width, height);
        }
    
        public static void displayPngInfo(byte[] bytes)
        {
            long width = 0;
    
            width = width | bytes[0];
            width = width << 8;
            width = width | bytes[1];
            width = width << 8;
            width = width | bytes[2];
            width = width << 8;
            width = width | bytes[3];       
    
            long height = 0;
    
            height = height | bytes[4];
            height = height << 8;
            height = height | bytes[5];
            height = height << 8;
            height = height | bytes[6];
            height = height << 8;
            height = height | bytes[7];
    
            Console.WriteLine("PNG\nWidth: {0}\nHeight: {1}\n", width, height);  
        }
    }
