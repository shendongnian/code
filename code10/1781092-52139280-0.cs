     private static IList<InkStroke> GetScaledAndTransformedStrokes(IList<InkStroke> strokeList, float scale)
            {
                var builder = new InkStrokeBuilder();
                var newStrokeList = new List<InkStroke>();
                var boundingBox = strokeList.GetBoundingBox();
    
                foreach (var singleStroke in strokeList)
                {  
                    var translateMatrix = new Matrix(1, 0, 0, 1, -boundingBox.X, -boundingBox.Y);
    
                    var newInkPoints = new List<InkPoint>();
                    var originalInkPoints = singleStroke.GetInkPoints();
                    foreach (var point in originalInkPoints)
                    {
                        var newPosition = translateMatrix.Transform(point.Position);
                        var newInkPoint = new InkPoint(newPosition, point.Pressure, point.TiltX, point.TiltY, point.Timestamp);
                        newInkPoints.Add(newInkPoint);
                    }
        
                    var newStroke = builder.CreateStrokeFromInkPoints(newInkPoints, new Matrix3x2(scale, 0, 0, scale, 0, 0));
        
                    newStrokeList.Add(newStroke);
                }
    
                return newStrokeList;
            }
