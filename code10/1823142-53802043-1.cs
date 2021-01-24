    public class ZoomFactor
    {
        public ZoomFactor() { }
        public PointF TranslateZoomPosition(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF ImageOrigin = GetImageScaledOrigin(Coordinates, ContainerSize, ImageSize);
            float ScaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            return new PointF(ImageOrigin.X / ScaleFactor, ImageOrigin.Y / ScaleFactor);
        }
        public RectangleF TranslateZoomSelection(RectangleF SelectionRect, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF SelectionTrueOrigin = TranslateZoomPosition(SelectionRect.Location, ContainerSize, ImageSize);
            float ScaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            SizeF SelectionTrueSize = new SizeF(SelectionRect.Width / ScaleFactor, SelectionRect.Height / ScaleFactor);
            return new RectangleF(SelectionTrueOrigin, SelectionTrueSize);
        }
        public PointF GetImageScaledOrigin(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            SizeF ImageScaleSize = GetImageScaledSize(ContainerSize, ImageSize);
            PointF ImageOrigin = new PointF((ContainerSize.Width / 2 - ImageScaleSize.Width / 2),
                                            (ContainerSize.Height / 2 - ImageScaleSize.Height / 2));
            return new PointF(Coordinates.X - ImageOrigin.X, Coordinates.Y - ImageOrigin.Y);
        }
        public SizeF GetImageScaledSize(SizeF ContainerSize, SizeF ImageSize)
        {
            float ScaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            return new SizeF(ImageSize.Width * ScaleFactor, ImageSize.Height * ScaleFactor);
        }
        internal float GetScaleFactor(SizeF Scaled, SizeF Original)
        {
            return (Original.Width > Original.Height) ? (Scaled.Width / Original.Width)
                                                      : (Scaled.Height / Original.Height);
        }
    }
