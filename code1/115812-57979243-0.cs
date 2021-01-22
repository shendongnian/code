    Pen myPen = new Pen(Brushes.Black);
    myPen.Width = 8.0f;
    // Set the LineJoin property
    myPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
    
    // Draw the rectangle
    e.Graphics.DrawRectangle(myPen, new Rectangle(50, 50, 200, 200));
