    ImageCache c = new ImageCache();
    string path = @"c:\somepath\image.jpg";
    if (c.Contains(path))
    {
        return c[path];
    }
    else
    {
        // put something into the cache
    }
