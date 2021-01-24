    public static Icon IconFromFilePath(string filePath)
    {
        var result = (Icon)null;
        try
        {
            result = Icon.ExtractAssociatedIcon(filePath);
        }
        catch (System.Exception)
        {
        }
        return result;
    }
    public Bitmap FromIconToBitmap(Icon icon)
    {
        Bitmap bmp = new Bitmap(icon.Width, icon.Height);
        using (Graphics gp = Graphics.FromImage(bmp))
        {
            gp.Clear(Color.Transparent);
            gp.DrawIcon(icon, new Rectangle(0, 0, icon.Width, icon.Height));
        }
        return bmp;
    }
    public static byte[] ImageToByte(Image img)
    {
        ImageConverter converter = new ImageConverter();
        return (byte[])converter.ConvertTo(img, typeof(byte[]));
    }
