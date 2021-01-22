       // Use rectTristrip.Strip.Length instead of NoOfStrips
       // to let the JIT eliminate bounds checking
       // .Count if it is a list instead of array
       for (int i = 0; i < rectTristrip.Strip.Length; i++)
       {
           VertexList verList = rectTristrip.Strip[i]; // Removed 'new'
           GraphicsPath rectPath4 = verList.TristripToGraphicsPath();
           // Assuming pointList is infact a list, do this:
           pointList.AddRange(rectPath4.PathPoints);
           // Else do this:
           // Use PathPoints.Length instead of PointCount
           // to let the JIT eliminate bounds checking
           for (int j = 0; j < rectPath4.PathPoints.Length; j++)
           {
               pointList.Add(rectPath4.PathPoints[j]);
           }
       }
