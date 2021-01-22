    public dynamic Abs(dynamic dyn)
    {
        if (dyn.GetType() = typeof(Angle))
        {
            return Abs(dyn);
        }
        else
        {
            return System.Math.Abs(dyn);
        }
    }
