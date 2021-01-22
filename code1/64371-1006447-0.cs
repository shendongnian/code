    ImageQualitySetting ImgQual = ImageQualitySetting.PDFReady_VeryHigh;
    int Width = 50;
    
    int Height = 50;
    
    Font TextFont = New Font("Tahoma", 14, FontStyle.Bold)
    
    Bitmap bmp = New Bitmap(Width, Height);
    
    bmp.SetResolution(ImgQual, ImgQual);
    
    System.Drawing.Graphics g = Graphics.FromImage(bmp);
    
    System.Drawing.StringFormat sf = New System.Drawing.StringFormat();
    sf.Alignment = StringAlignment.Center;
    g.DrawString("a", NumberTextFont, Brushes.Black, New RectangleF(0, 0, Width, Height), sf);
    return bmp;
