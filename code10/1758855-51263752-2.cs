    var allPoints = new List <DataPoint>();
    for (int s = 0; s < 3; s++)  // I know I have create these three series
    {
        Series ser = chartGraphic.Series["S" + (s+1)];
        allPoints.AddRange(ser.Points);
    }
