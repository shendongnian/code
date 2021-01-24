    RectangleF DestinationRect = new RectangleF(Point.Empty, InflatedBitmap); 
    SizeF ScaleFactor = new SizeF(DestinationRect.Width / SourceRect.Width, 
                                  DestinationRect.Height / SourceRect.Height);
    PointF Position = new PointF(SelectionRect.X * ScaleFactor.Width, SelectionRect.Y * ScaleFactor.Height);
    SizeF NewSize = new SizeF(SelectionRect.Width * ScaleFactor.Width, SelectionRect.Height * ScaleFactor.Height);
    Rectangle InflatedSelection = new Rectangle(Point.Round(Position), Size.Round(NewSize));
