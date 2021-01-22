    using System;
    using System.IO;
    using System.Text;
    
    public class ImageSizeTest
    {
        public static void Main()
        {
    		byte[] bytes = new byte[10];
    		
    		string gifFile = @"D:\Personal\Images&Pics\iProduct.gif";
    		using (FileStream fs = File.OpenRead(gifFile))
    		{
    			fs.Read(bytes, 0, 10); // type (3 bytes), version (3 bytes), width (2 bytes), height (2 bytes)
    		}
    		displayGifInfo(bytes);
    
    		string pngFile = @"D:\Personal\Images&Pics\WaveletsGamma.png";
    		using (FileStream fs = File.OpenRead(pngFile))
    		{
    			fs.Seek(16, SeekOrigin.Begin); // jump to the 16th byte where width and height information is stored
    			fs.Read(bytes, 0, 8); // width (4 bytes), height (4 bytes)
    		}
    	    displayPngInfo(bytes);
        }
    
        public static void displayGifInfo(byte[] bytes)
        {
    		string type = Encoding.ASCII.GetString(bytes, 0, 3);
            string version = Encoding.ASCII.GetString(bytes, 3, 3);
    
    		int width = bytes[6] | bytes[7] << 8; // byte 6 and 7 contain the width but in network byte order so byte 7 has to be left-shifted 8 places and bit-masked to byte 6
            int height = bytes[8] | bytes[9] << 8; // same for height
    
    		Console.WriteLine("GIF\nType: {0}\nVersion: {1}\nWidth: {2}\nHeight: {3}\n", type, version, width, height);
        }
    
        public static void displayPngInfo(byte[] bytes)
        {
            int width = 0, height = 0;
    		
    		for (int i = 0; i <= 3; i++)
    		{
    			width = bytes[i] | width << 8;
    			height = bytes[i + 4] | height << 8;			
    		}
    
            Console.WriteLine("PNG\nWidth: {0}\nHeight: {1}\n", width, height);  
        }
    }
