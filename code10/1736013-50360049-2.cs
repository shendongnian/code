    RectangleF DestinationRect = new RectangleF(Point.Empty, InflatedBitmap.Size); 
    SizeF ScaleFactor = new SizeF(DestinationRect.Width / SourceRect.Width, 
                                  DestinationRect.Height / SourceRect.Height);
    PointF NewPosition = new PointF(SelectionRect.X * ScaleFactor.Width, SelectionRect.Y * ScaleFactor.Height);
    SizeF NewSize = new SizeF(SelectionRect.Width * ScaleFactor.Width, SelectionRect.Height * ScaleFactor.Height);
    RectangleF InflatedSelection = new RectangleF(NewPosition, NewSize);
