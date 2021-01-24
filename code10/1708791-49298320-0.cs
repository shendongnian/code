    using (MagickImage image = new MagickImage(bitmap))
        {
            using (IMagickImage backgroundImg = image.Clone())
            {
                backgroundImg.Blur(0, 5);
                backgroundImg.Crop(400, 300, Gravity.Center);
                backgroundImg.RePage();
                image.Resize(0, 300);
                IMagickImage _shadow = new MagickImage(MagickColor.FromRgb(0, 0, 0), image.Width + 20, 400);
    _shadow.Shadow(backgroundImg.Width, 400, 10, (Percentage)90);
                backgroundImg.Composite(_shadow, Gravity.Center, CompositeOperator.Atop);
                backgroundImg.Composite(image, Gravity.Center, CompositeOperator.SrcAtop);
                backgroundImg.Write(@"C:\Users\David\Pictures\NEWest.png");
            }
        }
