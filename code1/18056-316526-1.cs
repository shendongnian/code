    int wfactor = 4; // half the line width, kinda
    // create 7 points for path
    Point[] pts = {
        new Point(0, 0), 
        new Point(wfactor, 0), 
        new Point(Width, Height - wfactor),
        new Point(Width, Height) ,
        new Point(Width - wfactor, Height),
        new Point(0, wfactor),
        new Point(0, 0) };
    // magic numbers! 
    byte[] types = {
        0, // start point
        1, // line
        1, // line
        1, // line
        1, // line
        1, // line
        1 | 8 }; // line OR closepath
    GraphicsPath path = new GraphicsPath(pts, types);
    this.Region = new Region(path);
