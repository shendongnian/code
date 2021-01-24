    // the verteses has to be in order and direction doesn't matter here 
    // i simply assume it's drawn on X/Y for the purpose of the example
    public static Region CreateRegion(List<Point3D> verteses)
    {
        // create a curve list representing
        var curves = new List<ICurve>();
        // for each vertex we add them to the list
        for (int i = 1; i < verteses.Count; i++)
        {
            curves.Add(new Line(verteses[i - 1], verteses[i]));
        }
        // close the region
        curves.Add(new Line(verteses.Last(), verteses[0]));
         return new Region(new CompositeCurve(curves, true), Plane.XY, true);
    }
    // this extrude in Z the region
    public static Solid CreateSolidFromRegion(Region region, double extrudedHeight)
    {
        // extrude toward Z by the amount
        return region.ExtrudeAsSolid(new Vector3D(0, 0, 1), extrudedHeight);
    }
