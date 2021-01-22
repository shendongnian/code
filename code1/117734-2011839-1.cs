    int rMax = Color.Chocolate.R;
    int rMin = Color.Blue.R;
    // ... and for B, G
    var colorList = new List<Color>();
    for(int i=0; i<size; i++)
    {
        var rAverage = rMin + (int)((rMax - rMin) * i / size);
        var gAverage = gMin + (int)((gMax - gMin) * i / size);
        var bAverage = bMin + (int)((bMax - bMin) * i / size);
        colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
    }
