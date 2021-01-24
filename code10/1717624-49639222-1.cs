    public static void AddTriangle(this MeshGeometry3D mesh, Point3D[] pts)
    {
        if (pts.Count() != 3) return;
        //use the three point of the triangle to calculate the normal (angle of the surface)
        Vector3D normal = CalculateNormal(pts[0], pts[1], pts[2]);
        normal.Normalize();
        //calculate the uv products
        Vector3D u;
        if (normal.X == 0 && normal.Z == 0) u = new Vector3D(normal.Y, -normal.X, 0);
        else u = new Vector3D(normal.X, -normal.Z, 0);
        u.Normalize();
        Vector3D n = new Vector3D(normal.Z, normal.X, normal.Y);
        Vector3D v = Vector3D.CrossProduct(n, u);
        int index = mesh.Positions.Count;
        foreach (Point3D pt in pts)
        {
            //add the points to create the triangle
            mesh.Positions.Add(pt);
            mesh.TriangleIndices.Add(index++);
            //apply the uv texture positions
            double u_coor = Vector3D.DotProduct(u, new Vector3D(pt.Z,pt.X,pt.Y));
            double v_coor = Vector3D.DotProduct(v, new Vector3D(pt.Z, pt.X, pt.Y));
            mesh.TextureCoordinates.Add(new Point(u_coor, v_coor));            
        }
    }
    private static Vector3D CalculateNormal(Point3D firstPoint, Point3D secondPoint, Point3D thirdPoint)
    {
        var u = new Point3D(firstPoint.X - secondPoint.X,
            firstPoint.Y - secondPoint.Y,
            firstPoint.Z - secondPoint.Z);
        var v = new Point3D(secondPoint.X - thirdPoint.X,
            secondPoint.Y - thirdPoint.Y,
            secondPoint.Z - thirdPoint.Z);
        return new Vector3D(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X);
    }
