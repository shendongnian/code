    // Get screen location of web browser
    Rectangle rec = webBrowser1.RectangleToScreen(webBrowser1.ClientRectangle);
    // create image to hold whats in view
    Bitmap image = new Bitmap(rec.Width, rec.Height);
    // get graphics to draw on image
    Graphics g = Graphics.FromImage(image);
    // Save into image
    // From MSDN:
    //public void CopyFromScreen(
    //    int sourceX,
    //    int sourceY,
    //    int destinationX,
    //    int destinationY,
    //    Size blockRegionSize
    //)
    g.CopyFromScreen(rec.X,rec.Y,0,0,rec.Size)
