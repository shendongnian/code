    // Observe that the function doesn't use rZ,
    // it is expected that it will become zero vector in triangular form
    static Vector3 EigenVector(Vector3 rX, Vector3 rY, Vector3 rZ, float lambda)
    {
        // Move RHS to LHS
        rX.X -= lambda;
        rY.Y -= lambda;
        // Transform to upper triangle
        rY -= rX * (rY.X / rX.X);
        // Backsubstitute
        var res = new Vector3(1f);
        res.Y = -rY.Z / rY.Y;
        res.X = -(rX.Y * res.Y + rX.Z * res.Z) / rX.X;
        return res;
    }
    // Case of eigenvalue with algebraic multiplicity two
    static (Vector3, Vector3) EigenVector2(Vector3 rX, Vector3 rY, Vector3 rZ, float lambda)
    {
        // Move RHS to LHS
        rX.X -= lambda;
        float x2 = rX.Y / rX.X;
        float x3 = rX.Z / rX.X;
        return (new Vector3(x2, 1, 0), new Vector3(x3, 0, 1));
    }
    static void Main(string[] args)
    {
        var rX = new Vector3(1, -3, 3);
        var rY = new Vector3(3, -5, 3);
        var rZ = new Vector3(6, -6, 4);
        var e = EigenVector(rX, rY, rZ, 4);
        var e2 = EigenVector2(rX, rY, rZ, 2);
            
        System.Diagnostics.Debug.WriteLine(e.ToString());
        System.Diagnostics.Debug.WriteLine(e2.Item1.ToString());
        System.Diagnostics.Debug.WriteLine(e2.Item2.ToString());
    }
