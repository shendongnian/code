    public Matrix(int height, int width)
        {
            List<List<double>> points = new List<List<double>>();
    
            for (int i = 0; i < height; i++)
            {
                List<double> row = new List<double>();
     
                for (int i = 0; i < width; i++)
                {
                    row.Add(0.0d);
                }
                points.Add(row);
            }
    
            matrix = points;
        }
