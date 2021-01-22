    static double GetDeterminant(double x1, double y1, double x2, double y2)
    {
        return x1 * y2 - x2 * y1;
    }
    
    static double GetArea(IList<Vertex> vertices)
    {
        if(vertices.Count < 3)
        {
            return 0;
        }
        double area = GetDeterminant(vertices[vertices.Count - 1].X, vertices[vertices.Count - 1].Y, vertices[0].X, vertices[0].Y);
        for (int i = 1; i < vertices.Count; i++)
        {
            area += GetDeterminant(vertices[i - 1].X, vertices[i - 1].Y, vertices[i].X, vertices[i].Y);
        }
    	return area;
    }
