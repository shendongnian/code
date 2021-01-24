        public static double GetAngleBetweenPoints(Point p1, Point p2)
        {           
            double xDiff = p2.X - p1.X;
            double yDiff = p1.Y - p2.Y;
            double Angle = Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
            if (Angle < 0.0)
                Angle = Angle + 360.0;
            return Angle;
        }
     public static GenericList<Point> PointAddingByAngle(GenericList<Point> LinePoints2)
        {
            
            List<int> AnglefromCenterPointsofShapePoint = new List<int>();
            List<Point> Linepoints3 = new List<Point>(LinePoints2);
            List<Point> LinePoints = Linepoints3.Distinct().ToList();
            
            Point CenterPoint = new Point();
            CenterPoint.X = PolygonCenterX;
            CenterPoint.Y = PolygonCenterY;            
            
            for (int index = 0; index < LinePoints.Count; index++)
            {
                AnglefromCenterPointsofShapePoint.Add((int) Math.Round(GetAngleBetweenPoints(CenterPoint, LinePoints[index])));    
            }           
            
            AnglefromCenterPointsofShapePoint.Sort();
            int currentPointAngle = 0;
            
            for (int AngleListIndex = 0; AngleListIndex < AnglefromCenterPointsofShapePoint.Count; AngleListIndex++)
            {
                currentPointAngle = AnglefromCenterPointsofShapePoint[AngleListIndex];
                for (int index = 0; index < LinePoints.Count; index++)
                {
                    if ((Math.Round(GetAngleBetweenPoints(CenterPoint, LinePoints[index]))) == currentPointAngle)
                    {
                        SortedPoints.Add(LinePoints[index]);
                        break;
                    }
                }
            }
            
            SortedPoints.Add(SortedPoints[0]);
            return SortedPoints;
        }
       private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (PathPoints.Count > 2)
            {
                PathPoints.Add(PathPoints[0]);
                IsPathComplete = true;
                IsPointSelected = false;
                StartingPoint = PathPoints[0];
                EndingPoint = PathPoints[PathPoints.Count - 1];
            }
            if (IsPathComplete && NewPointAdd)
            {
                
                System.Drawing.Point Centerpoint = new System.Drawing.Point();
                
                PathPoints.Add(e.Location);
                
                MinMaxFinder(PathPoints);
                Centerpoint.X = PolygonCenterX;
                Centerpoint.Y = PolygonCenterY;
               
                lblAngle.Text = Convert.ToString(Math.Round(ShapeDirectory.GetAngleBetweenPoints(Centerpoint, e.Location)));
                PathPoints3.Clear();
                
                PathPoints3 = ShapeDirectory.PointAddingByAngle(PathPoints);
                PathPoints.Clear();
                foreach (System.Drawing.Point p in PathPoints3)
                {
                    PathPoints.Add(p);
                }
                PathPoints.Add(PathPoints3[0]);
                NewPointAddDraw = true;
            }
        }
