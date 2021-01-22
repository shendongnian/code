        public static RectangleF GetRectangle(PointF center, float radius)
        {
            var rectangle = new RectangleF(center.X - radius, center.Y - radius,radius * 2, radius * 2);
            return rectangle;
        }
        public static Region GetRingRegion(PointF center, float innerRadius, float outherRadius)
        {
            // You need a path for the outer and inner circles
            var path1 = new GraphicsPath();
            var path2 = new GraphicsPath();
            // Define the paths (where X, Y, and D are chosen externally)
            path1.AddEllipse(GetRectangle(center,outherRadius));
            path2.AddEllipse(GetRectangle(center, innerRadius));
            // Create a region from the Outer circle.
            Region region = new Region(path1);
            // Exclude the Inner circle from the region
            region.Exclude(path2);
            return region;
        }
