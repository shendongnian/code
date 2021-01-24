    /// <summary>
    /// Wraps angle between 0 and 360
    /// </summary>
    /// <param name="angle">The angle</param>
    /// <returns>A bounded angle value</returns>
    public static double WrapTo360(this double angle) 
        => angle-360*Math.Floor(angle/360);
    /// <summary>
    /// Wraps angle between -180 and 180
    /// </summary>
    /// <param name="angle">The angle</param>
    /// <returns>A bounded angle value</returns>
    /// <remarks>see: http://stackoverflow.com/questions/7271527/inconsistency-with-math-round</remarks>
    public static double WrapBetween180(this double angle)
        => angle+360*Math.Floor((180-angle)/360);
