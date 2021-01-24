    var c = Color.Red;
    EuclideanColorFiltering filter = new EuclideanColorFiltering();
    filter.CenterColor = new RGB(color.R, color.G, color.B);
    filter.Radius = (short)radius;
    filter.ApplyInPlace(input);
