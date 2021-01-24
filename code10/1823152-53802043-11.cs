    public class ZoomFactor
    {
        public ZoomFactor() { }
        public PointF TranslateZoomPosition(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF imageOrigin = TranslateCoordinatesOrigin(Coordinates, ContainerSize, ImageSize);
            float scaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            return new PointF(imageOrigin.X / scaleFactor, imageOrigin.Y / scaleFactor);
        }
        public RectangleF TranslateZoomSelection(RectangleF SelectionRect, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF selectionTrueOrigin = TranslateZoomPosition(SelectionRect.Location, ContainerSize, ImageSize);
            float scaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            SizeF selectionTrueSize = new SizeF(SelectionRect.Width / scaleFactor, SelectionRect.Height / scaleFactor);
            return new RectangleF(selectionTrueOrigin, selectionTrueSize);
        }
        public RectangleF TranslateSelectionToZoomedSel(RectangleF SelectionRect, SizeF ContainerSize, SizeF ImageSize)
        {
            float scaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            RectangleF zoomedSelectionRect = new
                RectangleF(SelectionRect.X * scaleFactor, SelectionRect.Y * scaleFactor,
                           SelectionRect.Width * scaleFactor, SelectionRect.Height * scaleFactor);
            PointF imageScaledOrigin = GetImageScaledOrigin(ContainerSize, ImageSize);
            zoomedSelectionRect.Location = new PointF(zoomedSelectionRect.Location.X + imageScaledOrigin.X,
                                                      zoomedSelectionRect.Location.Y + imageScaledOrigin.Y);
            return zoomedSelectionRect;
        }
        public PointF TranslateCoordinatesOrigin(PointF Coordinates, SizeF ContainerSize, SizeF ImageSize)
        {
            PointF imageOrigin = GetImageScaledOrigin(ContainerSize, ImageSize);
            return new PointF(Coordinates.X - imageOrigin.X, Coordinates.Y - imageOrigin.Y);
        }
        public PointF GetImageScaledOrigin(SizeF ContainerSize, SizeF ImageSize)
        {
            SizeF imageScaleSize = GetImageScaledSize(ContainerSize, ImageSize);
            return new PointF((ContainerSize.Width - imageScaleSize.Width) / 2,
                              (ContainerSize.Height - imageScaleSize.Height) / 2);
        }
        public SizeF GetImageScaledSize(SizeF ContainerSize, SizeF ImageSize)
        {
            float scaleFactor = GetScaleFactor(ContainerSize, ImageSize);
            return new SizeF(ImageSize.Width * scaleFactor, ImageSize.Height * scaleFactor);
        }
        internal float GetScaleFactor(SizeF Scaled, SizeF Original)
        {
            return (Original.Width > Original.Height) ? (Scaled.Width / Original.Width)
                                                      : (Scaled.Height / Original.Height);
        }
    }
