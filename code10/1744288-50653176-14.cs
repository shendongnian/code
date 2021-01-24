    while (listX.Count > 0 && listY.Count > 0)
       if (listX[0] > listY[0])
       {
          result.Add(listY[0]);
          listY.RemoveAt(0);
       }
       else
       {
          result.Add(listX[0]);
          listX.RemoveAt(0);
       }
                
    
    if (listX.Count > 0)
       result.AddRange(listX);
    else if (listY.Count > 0)
       result.AddRange(listY);
