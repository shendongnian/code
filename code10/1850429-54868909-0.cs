        using tessnet2;  
        using System.Drawing;  
        using System.Drawing.Drawing2D;  
        using System.Drawing.Imaging; 
 
        // now add the following C# line in the code page  
        var image = new Bitmap(@ "Z:\NewProject\demo\image.bmp");  
        varocr = new Tesseract();  
        ocr.Init(@ "Z:\NewProject\How to use Tessnet2 library\C#\tessdata", "eng", false);  
        var result = ocr.DoOCR(image, Rectangle.Empty);  
        foreach(tessnet2.Word word in result)  
        {  
            Console.writeline(word.text);  
        } 
