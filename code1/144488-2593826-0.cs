    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
     MemoryStream ms = new MemoryStream();
     imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
     return  ms.ToArray();
    }
