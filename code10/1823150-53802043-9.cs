    public class ZoomFactor
    {
        public ZoomFactor() { }
        public PointF TranslateZoomPosition(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF ImageOrigin = TranslateCoordinatesOrigin(Coordinates, ContainerSize, ImageSize);
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
        public RectangleF TranslateSelectionToZoomedSel(RectangleF SelectionRect, SizeF ContainerSize, SizeF ImageSize)
        {
            float ScaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            RectangleF ZoomedSelectionRect = new
                RectangleF(SelectionRect.X * ScaleFactor, SelectionRect.Y * ScaleFactor,
                           SelectionRect.Width * ScaleFactor, SelectionRect.Height * ScaleFactor);
            PointF ImageScaledOrigin = GetImageScaledOrigin(ContainerSize, ImageSize);
            ZoomedSelectionRect.Location = new PointF(ZoomedSelectionRect.Location.X + ImageScaledOrigin.X,
                                                      ZoomedSelectionRect.Location.Y + ImageScaledOrigin.Y);
            return ZoomedSelectionRect;
        }
        public PointF TranslateCoordinatesOrigin(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF ImageOrigin = GetImageScaledOrigin(ContainerSize, ImageSize);
            return new PointF(Coordinates.X - ImageOrigin.X, Coordinates.Y - ImageOrigin.Y);
        }
        public PointF GetImageScaledOrigin(SizeF ContainerSize, SizeF ImageSize)
        {
            SizeF ImageScaleSize = GetImageScaledSize(ContainerSize, ImageSize);
            return new PointF((ContainerSize.Width / 2 - ImageScaleSize.Width / 2),
                              (ContainerSize.Height / 2 - ImageScaleSize.Height / 2));
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
