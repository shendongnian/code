    public class ZoomFactor
    {
        public ZoomFactor() { }
        public PointF TranslateZoomPosition(PointF coordinates, SizeF containerSize, SizeF imageSize)
        {
            PointF imageOrigin = TranslateCoordinatesOrigin(coordinates, containerSize, imageSize);
            float scaleFactor = GetScaleFactor(containerSize, imageSize);
            return new PointF(imageOrigin.X / scaleFactor, imageOrigin.Y / scaleFactor);
        }
        public RectangleF TranslateZoomSelection(RectangleF selectionRect, SizeF containerSize, SizeF imageSize)
        {
            PointF selectionTrueOrigin = TranslateZoomPosition(selectionRect.Location, containerSize, imageSize);
            float scaleFactor = GetScaleFactor(containerSize, imageSize);
            SizeF selectionTrueSize = new SizeF(selectionRect.Width / scaleFactor, selectionRect.Height / scaleFactor);
            return new RectangleF(selectionTrueOrigin, selectionTrueSize);
        }
        public RectangleF TranslateSelectionToZoomedSel(RectangleF selectionRect, SizeF containerSize, SizeF imageSize)
        {
            float scaleFactor = GetScaleFactor(containerSize, imageSize);
            RectangleF zoomedSelectionRect = new
                RectangleF(selectionRect.X * scaleFactor, selectionRect.Y * scaleFactor,
                           selectionRect.Width * scaleFactor, selectionRect.Height * scaleFactor);
            PointF imageScaledOrigin = GetImageScaledOrigin(containerSize, imageSize);
            zoomedSelectionRect.Location = new PointF(zoomedSelectionRect.Location.X + imageScaledOrigin.X,
                                                      zoomedSelectionRect.Location.Y + imageScaledOrigin.Y);
            return zoomedSelectionRect;
        }
        public PointF TranslateCoordinatesOrigin(PointF coordinates, SizeF containerSize, SizeF imageSize)
        {
            PointF imageOrigin = GetImageScaledOrigin(containerSize, imageSize);
            return new PointF(coordinates.X - imageOrigin.X, coordinates.Y - imageOrigin.Y);
        }
        public PointF GetImageScaledOrigin(SizeF containerSize, SizeF imageSize)
        {
            SizeF imageScaleSize = GetImageScaledSize(containerSize, imageSize);
            return new PointF((containerSize.Width - imageScaleSize.Width) / 2,
                              (containerSize.Height - imageScaleSize.Height) / 2);
        }
        public SizeF GetImageScaledSize(SizeF containerSize, SizeF imageSize)
        {
            float scaleFactor = GetScaleFactor(containerSize, imageSize);
            return new SizeF(imageSize.Width * scaleFactor, imageSize.Height * scaleFactor);
        }
        internal float GetScaleFactor(SizeF scaled, SizeF original)
        {
            return (original.Width > original.Height) ? (scaled.Width / original.Width)
                                                      : (scaled.Height / original.Height);
        }
    }
