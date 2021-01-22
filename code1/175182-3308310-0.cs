    int renderingTier = (RenderCapability.Tier >> 16);
    if (renderingTier == 0)
    {
        Trace.WriteLine("No graphics hardware acceleration available");
    }
    else if (renderingTier == 1)
    {
        Trace.WriteLine("Partial graphics hardware acceleration available");
    }
    else if (renderingTier == 2)
    {
        Trace.WriteLine("Gotcha!!!");
    }
