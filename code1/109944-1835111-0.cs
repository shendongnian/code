    //
    // Summary:
    //     Draws an ellipse defined by a bounding rectangle specified by coordinates
    //     for the upper-left corner of the rectangle, a height, and a width.
    //
    // Parameters:
    //   pen:
    //     System.Drawing.Pen that determines the color, width,
    //      and style of the ellipse.
    //
    //   x:
    //     The x-coordinate of the upper-left corner of the bounding rectangle that
    //     defines the ellipse.
    //
    //   y:
    //     The y-coordinate of the upper-left corner of the bounding rectangle that
    //     defines the ellipse.
    //
    //   width:
    //     Width of the bounding rectangle that defines the ellipse.
    //
    //   height:
    //     Height of the bounding rectangle that defines the ellipse.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     pen is null.
    public void DrawEllipse(Pen pen, int x, int y, int width, int height);
