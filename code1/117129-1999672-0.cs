    public static class CoordinateTransformationHelper
    {
        public static Point ThumbToOriginal(this Point point, Size thumb, Size source)
        {
            Point rc = new Point();
            rc.X = (int)((double)point.X / thumb.Width * source.Width);
            rc.Y = (int)((double)point.Y / thumb.Height * source.Height);
            return rc;
        }
        public static Size ThumbToOriginal(this Size size, Size thumb, Size source)
        {
            Point pt = new Point(size);
            Size rc = new Size(pt.ThumbToOriginal(thumb, source));
            return rc;
        }
        public static Rectangle ThumbToOriginal(this Rectangle rect, Size thumb, Size source)
        {
            Rectangle rc = new Rectangle();
            rc.Location = rect.Location.ThumbToOriginal(thumb, source);
            rc.Size = rect.Size.ThumbToOriginal(thumb, source);
            return rc;
        }
    }
