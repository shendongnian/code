    Bitmap FinalBitmap = new Bitmap();
    MemoryStream msStream = new MemoryStream();
    strInputParameter == Request.Params("MagicParm").ToString()
    // Magic code goes here to generate your bitmap image.
    FinalBitmap.Save(msStream, ImageFormat.Png);
        
    Response.Clear();
    Response.ContentType = "image/png";
        
    msStream.WriteTo(Response.OutputStream);
        
    if ((FinalBitmap != null)) FinalBitmap.Dispose();
