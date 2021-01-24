    List<Point> filteredList = new List<Point>();
    for(int i = 0; i < patternTrackingInfo.points2d.Count; i++)
    {
        if(/*Do your check here*/)
            continue;
        filteredList.Add(patternTrackingInfo.points2d[i]);
    }
    Point[] ptsArray = filteredList.toArray();              
    pt1 = ptsArray[0];
    pt2 = ptsArray[2];     
    pt3 = new OpenCVForUnity.CoreModule.Point(ptsArray[2].x + 5, ptsArray[2].y + 5);                               
    
    for (int i = 0; i < 4; i++)
    {
        cropRect = new OpenCVForUnity.CoreModule.Rect(pt1, pt3);
    }
