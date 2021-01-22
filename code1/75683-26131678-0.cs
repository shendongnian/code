    using (MagickImageCollection collection = new MagickImageCollection())
    {
      // Add first image and set the animation delay to 100ms
      collection.Add("Snakeware.png");
      collection[0].AnimationDelay = 100;
    
      // Add second image, set the animation delay to 100ms and flip the image
      collection.Add("Snakeware.png");
      collection[1].AnimationDelay = 100;
      collection[1].Flip();
    
      // Optionally reduce colors
      QuantizeSettings settings = new QuantizeSettings();
      settings.Colors = 256;
      collection.Quantize(settings);
    
      // Optionally optimize the images (images should have the same size).
      collection.Optimize();
    
      // Save gif
      collection.Write("Snakeware.Animated.gif");
    }
