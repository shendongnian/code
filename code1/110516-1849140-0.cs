            for (int ra = 0; ra <= 24; ra = ra + 3)
            {
                figure = new PathFigure();
                segment = new PolyLineSegment();
                for (int dec = -90; dec <= 90; dec = dec + 3)    
                {        
                    points = coords.GetAitoffCoord(ra, dec);        
                    double xCoord = xCenter + points.X * width / 2;        
                    double yCoord = yCenter + points.Y * height / 2;        
                    segment.Points.Add(new Point(xCoord, yCoord));                      
                }
                figure.StartPoint = segment.Points[0];
                figure.Segments.Add(segment);
                geometry.Figures.Add(figure);
            }
            
            for (int dec = -90; dec <= 90; dec = dec + 30)
            {
                figure = new PathFigure();
                segment = new PolyLineSegment();
                for (int ra = 0; ra <= 12; ra = ra + 1)
                {
                    points = coords.GetAitoffCoord(ra, dec);
                    double xCoord = xCenter + points.X * width / 2;
                    double yCoord = yCenter + points.Y * height / 2;
                    segment.Points.Add(new Point(xCoord, yCoord));
                }
                figure.StartPoint = segment.Points[0];
                figure.Segments.Add(segment);
                geometry.Figures.Add(figure);
            }
            for (int dec = -90; dec <= 90; dec = dec + 30)
            {
                figure = new PathFigure();
                segment = new PolyLineSegment();
                for (double ra = 12.01; ra <= 25; ra++)
                {
                    points = coords.GetAitoffCoord(ra, dec);
                    double xCoord = xCenter + points.X * width / 2;
                    double yCoord = yCenter + points.Y * height / 2;
                    segment.Points.Add(new Point(xCoord, yCoord));
                }
                figure.StartPoint = segment.Points[0];
                figure.Segments.Add(segment);
                geometry.Figures.Add(figure);
            }
            figure = new PathFigure();
            segment = new PolyLineSegment();
            for (int dec = -90; dec <= 90; dec = dec + 3)
            {
                double ra = 12.01;
                points = coords.GetAitoffCoord(ra, dec);
                double xCoord = xCenter + points.X * width / 2;
                double yCoord = yCenter + points.Y * height / 2;
                segment.Points.Add(new Point(xCoord, yCoord));
            }
            figure.StartPoint = segment.Points[0];
            figure.Segments.Add(segment);
            geometry.Figures.Add(figure);
