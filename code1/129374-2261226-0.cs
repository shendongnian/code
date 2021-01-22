    interface IImage
    {
        void DrawLine(Point startPoint, Point endPoint);
    }
    class MonochromeImage:IImage
    {
        void DrawLine(Point startPoint, Point endPoint)
        {
            //Draw a monochrome line on images with one channel
        }
    }
    class ColorImage:IImage
    {
        void DrawLine(Point startPoint, Point endPoint)
        {
            //Draw a red line on images with three channels
        }
    }
    ...
    void DrawLineOnImage()
    {
        List<IImage> images = new List<IImage>();
        images.Add(new ColorImage());
        images.Add(new MonochromeImage());
        //I am not aware of what kind of images actually have
        //all it matters is to have a draw line method
        foreach(IImage image in images)
        {
            image.DrawLine(p1,p2)
        }
    }
