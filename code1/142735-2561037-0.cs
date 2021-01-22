    public bool IsNotBlackImage()
    {
        Assembly assembly = this.GetType().Assembly;
        var imgTest = new Bitmap(assembly.GetManifestResourceStream("TestImage.png"));
        var imgStatistics = new ImageStatistics(imgTest);             
        return imgStatistics.PixelsCountWithoutBlack != 0;
    }
