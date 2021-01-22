        private void SplitGeometry(Geometry geo, Point pt1, Point pt2, out PathGeometry leftGeo, out PathGeometry rightGeo)
        {
            double c = 360.0 + 90.0 - (180.0 / Math.PI * Math.Atan2(pt2.Y - pt1.Y, pt2.X - pt1.X));
            var t = new TransformGroup();
            t.Children.Add(new TranslateTransform(-pt1.X, -pt1.Y));
            t.Children.Add(new RotateTransform(c));
            var i = t.Inverse;
            leftGeo = new PathGeometry();
            rightGeo = new PathGeometry();
            foreach (var figure in geo.GetFlattenedPathGeometry().Figures)
            {
                var left = new List<Point>();
                var right = new List<Point>();
                var lastPt = t.Transform(figure.StartPoint);
                foreach (PolyLineSegment segment in figure.Segments)
                {
                    foreach (var currentPtOrig in segment.Points)
                    {
                        var currentPt = t.Transform(currentPtOrig);
                        ProcessLine(lastPt, currentPt, left, right);
                        lastPt = currentPt;
                    }
                }
                ProcessFigure(left, i, leftGeo);
                ProcessFigure(right, i, rightGeo);
            }
        }
        private void ProcessFigure(List<Point> points, GeneralTransform transform, PathGeometry geometry)
        {
            if (points.Count == 0) return;
            var result = new PolyLineSegment();
            var prev = points[0];
            for (int i = 1; i < points.Count; ++i)
            {
                var current = points[i];
                if (current == prev) continue;
                result.Points.Add(transform.Transform(current));
                prev = current;
            }
            if (result.Points.Count == 0) return;
            geometry.Figures.Add(new PathFigure(transform.Transform(points[0]), new PathSegment[] { result }, true));
        }
        private void ProcessLine(Point pt1, Point pt2, List<Point> left, List<Point> right)
        {
            if (pt1.X >= 0 && pt2.X >= 0)
            {
                right.Add(pt1);
                right.Add(pt2);
            }
            else if (pt1.X < 0 && pt2.X < 0)
            {
                left.Add(pt1);
                left.Add(pt2);
            }
            else if (pt1.X < 0)
            {
                double c = (Math.Abs(pt1.X) * Math.Abs(pt2.Y - pt1.Y)) / Math.Abs(pt2.X - pt1.X);
                double y = pt1.Y + c * Math.Sign(pt2.Y - pt1.Y);
                var p = new Point(0, y);
                left.Add(pt1);
                left.Add(p);
                right.Add(p);
                right.Add(pt2);
            }
            else
            {
                double c = (Math.Abs(pt1.X) * Math.Abs(pt2.Y - pt1.Y)) / Math.Abs(pt2.X - pt1.X);
                double y = pt1.Y + c * Math.Sign(pt2.Y - pt1.Y);
                var p = new Point(0, y);
                right.Add(pt1);
                right.Add(p);
                left.Add(p);
                left.Add(pt2);
            }
        }
