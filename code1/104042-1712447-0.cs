    public Matrix(int height, int width)
    {
        List<List<double>> points = new List<List<double>>(height); // Might as well set the default capacity...
        for (int j = 0; j < height; j++) 
        {
            List<double> row = new List<double>(width);
            for (int i = 0; i < width; i++)
            {
                row.Add(0.0d);
            }
            points.Add(row);
        }
        matrix = points;
    }
