    var crop = new Rectangle(0, y, bitmap.Width, h);
    var bmp = new Bitmap(bitmap.Width, h);
    var tempfile = Application.StartupPath+"\\"+"TEMP"+"\\"+Path.GetRandomFileName();
    
    using (var gr = Graphics.FromImage(bmp))
    {
        try
        {
            var dest = new Rectangle(0, 0, bitmap.Width, h);
            gr.DrawImage(image,dest , crop, GraphicsUnit.Point);
            bmp.Save(tempfile,ImageFormat.Jpeg);
            bmp.Dispose();
        }
        catch (Exception)
        {
            
            
        }
        
    }
