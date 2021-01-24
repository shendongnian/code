    Bitmap imgIn;
    try
    {
        imgIn = new Bitmap(path);
        double y = imgIn.Height;
        double x = imgIn.Width;
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
