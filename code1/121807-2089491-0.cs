    public Angle Abs(Angle agl)
    {
       return (360 - Angle.Degrees);
    }
    public dynamic Abs(dynamic n) 
    {
       return Math.Abs(n);
    }
    Abs((dynamic)F[0]) // This is needed, because F[0] is probably of type <object>
