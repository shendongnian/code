    public static Bitmap ByteToBitmap(byte[] imageByte)
    {
    using (MemoryStream mStream = new MemoryStream(imageByte))
       {
        var s= SvgDocument.Open(mStream);
        var bm= svgDocument.Draw();
        return bm;
       }
    }
