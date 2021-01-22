    // This is much quicker...
    double result;
    if (!double.TryParse("Twelve", out result))
    {
        result = -1;
    }
    return result;
    // Than this...
    try
    {
        return double.Parse("Twelve");
    }
    catch 
    {
        return -1;
    }
