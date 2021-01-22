    public static double GetDouble(object input, double defaultVal)
    {
        double parsed;
        return double.TryParse(input.ToString(), out parsed)) ? parsed : defaultVal;
    }
