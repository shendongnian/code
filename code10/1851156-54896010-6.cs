    /// <summary>
    /// Wraps angle between 0 and 2π
    /// </summary>
    /// <param name="angle">The angle</param>
    /// <returns>A bounded angle value</returns>
    public static double WrapTo2PI(this double angle) 
        => angle-(2*Math.PI)*Math.Floor(angle/(2*Math.PI));
    /// <summary>
    /// Wraps angle between -π and π
    /// </summary>
    /// <param name="angle">The angle</param>
    /// <returns>A bounded angle value</returns>
    public static double WrapBetweenPI(this double angle) 
        => angle+(2*Math.PI)*Math.Floor((Math.PI-angle)/(2*Math.PI));
