    public static Intersection IntersectionOf(Line line1, Line line2)
        {
            //  Fail if either line segment is zero-length.
            if (line1.X1 == line1.X2 && line1.Y1 == line1.Y2 || line2.X1 == line2.X2 && line2.Y1 == line2.Y2)
                return Intersection.None;
            if (line1.X1 == line2.X1 && line1.Y1 == line2.Y1 || line1.X2 == line2.X1 && line1.Y2 == line2.Y1)
                return Intersection.Intersection;
            if (line1.X1 == line2.X2 && line1.Y1 == line2.Y2 || line1.X2 == line2.X2 && line1.Y2 == line2.Y2)
                return Intersection.Intersection;
            //  (1) Translate the system so that point A is on the origin.
            line1.X2 -= line1.X1; line1.Y2 -= line1.Y1;
            line2.X1 -= line1.X1; line2.Y1 -= line1.Y1;
            line2.X2 -= line1.X1; line2.Y2 -= line1.Y1;
            //  Discover the length of segment A-B.
            double distAB = Math.Sqrt(line1.X2 * line1.X2 + line1.Y2 * line1.Y2);
            //  (2) Rotate the system so that point B is on the positive X axis.
            double theCos = line1.X2 / distAB;
            double theSin = line1.Y2 / distAB;
            double newX = line2.X1 * theCos + line2.Y1 * theSin;
            line2.Y1 = line2.Y1 * theCos - line2.X1 * theSin; line2.X1 = newX;
            newX = line2.X2 * theCos + line2.Y2 * theSin;
            line2.Y2 = line2.Y2 * theCos - line2.X2 * theSin; line2.X2 = newX;
            //  Fail if segment C-D doesn't cross line A-B.
            if (line2.Y1 < 0 && line2.Y2 < 0 || line2.Y1 >= 0 && line2.Y2 >= 0)
                return Intersection.None;
            //  (3) Discover the position of the intersection point along line A-B.
            double posAB = line2.X2 + (line2.X1 - line2.X2) * line2.Y2 / (line2.Y2 - line2.Y1);
            //  Fail if segment C-D crosses line A-B outside of segment A-B.
            if (posAB < 0 || posAB > distAB)
                return Intersection.None;
            //  (4) Apply the discovered position to line A-B in the original coordinate system.
            return Intersection.Intersection;
        }
