    using (Image image = Image.FromFile("somefile.gif"))
    {
        if (ImageAnimator.CanAnimate(image))
        {
            // GIF is animated
        }
        else
        {
            // GIF is not animated
        }
    }
