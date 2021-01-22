    // Create a brush
    SolidBrush b = new SolidBrush(Color.Blue);
    
    // Clear your Graphics object (defined externally)
    gfx.Clear(Color.White);
    
    // You need a path for the outer and inner circles
    GraphicsPath path1 = new GraphicsPath();
    GraphicsPath path2 = new GraphicsPath();
    
    // Define the paths (where X, Y, and D are chosen externally)
    path1.AddEllipse((float)(X - D / 2), (float)(Y - D / 2), (float)D, (float)D);
    path2.AddEllipse((float)(X - D / 4), (float)(Y - D / 4), (float)(D / 2), (float)(D / 2));
    
    // Create a region from the Outer circle.
    Region region = new Region(path1);
    
    // Exclude the Inner circle from the region
    region.Exclude(path2);
    
    // Draw the region to your Graphics object
    gfx.FillRegion(b, region);
