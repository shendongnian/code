    public Point3D Rotate(Point3D point, Point3D rotationCenter, Vector3D rotation, double degree)
    {
        // create empty matrix
        var matrix = new Matrix3D();
    
        // translate matrix to rotation point
        matrix.Translate(rotationCenter - new Point3D());
    
        // rotate it the way we need
        matrix.Rotate(new Quaternion(rotation, degree));
    
        // apply the matrix to our point
        point = matrix.Transform(point);
    
        return point;
    }
