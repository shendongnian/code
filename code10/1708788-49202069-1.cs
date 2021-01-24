    using (MagickImage image = new MagickImage("i:/YnTf9.png"))
    {
        using (IMagickImage backgroundImg = image.Clone())
        {
            backgroundImg.Blur(0, 5);
            backgroundImg.Crop(400, 300, Gravity.Center);
            backgroundImg.RePage();
            // Resize the original image instead of creating a clone, resizing it and then
            // delete the original.
            image.Resize(0, 300);
            backgroundImg.Composite(image, Gravity.Center, CompositeOperator.SrcOver);
            backgroundImg.Write("i:/result.png");
        }
     }
